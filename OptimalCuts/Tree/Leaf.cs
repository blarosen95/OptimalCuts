using System;
using System.Diagnostics.Contracts;

namespace OptimalCuts.Tree
{
    public class Leaf : Node
    {
        public Panel _data;

        public Leaf(Panel data)
        {
            this._data = data;
        }

        public override double FitFactor(Piece p)
        {
            if (!_data.IsFree())
            {
                return 0;
            }

            double availableLength = _data._y2 - _data._y1;
            double availableWidth = _data._x2 - _data._x1;

            if (availableWidth < p._width || availableLength < p._length)
            {
                return 0;
            }

            // FIXME: Equality comparison of floating point numbers.
            if (availableWidth == p._width && availableLength == p._length)
            {
                return Double.MaxValue;
            }

            double remainingLength = availableLength - p._length;
            double remainingWidth = availableWidth - p._width;

            // Minimize remainder with this factor
            return 1.0d / (remainingWidth + remainingLength);
        }

        public override Node Arrange(Piece p)
        {
            if (FitFactor(p) == 0)
            {
                return null;
            }

            Panel arrangedPanel = new Panel(_data._x1, _data._y1, _data._x1 + p._width, _data._y1 + p._length);

            arrangedPanel.SetFree(false);

            Node arranged = new Leaf(arrangedPanel);

            Node remainingNode = GetAllPartitions(_data, arrangedPanel);

            if (remainingNode != null)
            {
                return new AndNode(arranged, remainingNode);
            }

            return arranged;
        }

        private Node GetAllPartitions(Panel original, Panel arranged)
        {
            double remainingLength = original._y2 - arranged._y2;
            double remainingWidth = original._x2 - arranged._x2;

            if (remainingWidth == 0 && remainingLength == 0)
            {
                // No remainder exists for us to partition.
                return null;
            }

            else if (remainingWidth == 0)
            {
                Panel p = new Panel(original._x1, arranged._y2, original._x2, original._y2);
                p.SetFree(true);
                return new Leaf(p);
            }
            else if (remainingLength == 0)
            {
                Panel p = new Panel(arranged._x2, original._y1, original._x2, original._y2);
                p.SetFree(true);
                return new Leaf(p);
            }
            else
            {
                return new OrNode(DivideRemainder(original, arranged, 1), DivideRemainder(original, arranged, 2));
            }
        }

        private AndNode DivideRemainder(Panel original, Panel arranged, int partitionType)
        {
            double x1 = original._x1;
            double x2 = original._x2;
            double y1 = original._y1;
            double y2 = original._y2;

            double xm = arranged._x2;
            double ym = arranged._y2;

            Contract.Assert(x1 < xm && xm < x2);
            Contract.Assert(y1 < ym && ym < y2);

            Panel p1, p2;

            if (partitionType == 1)
            {
                p1 = new Panel(xm, y1, x2, ym);
                p2 = new Panel(x1, ym, x2, y2);
            }
            else
            {
                p1 = new Panel(xm, y1, x2, y2);
                p2 = new Panel(x1, ym, xm, y2);
            }

            p1.SetFree(true);
            p2.SetFree(true);

            Leaf l1 = new Leaf(p1);
            Leaf l2 = new Leaf(p2);

            AndNode and = new AndNode(l1, l2);
            return and;
        }

        public override Panel[] GetPanels()
        {
            return new Panel[] { _data };
        }

        public override string ToString()
        {
            return $"Leaf {_data}";
        }
    }
}