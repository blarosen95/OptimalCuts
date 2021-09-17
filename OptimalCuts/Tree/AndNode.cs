using System;

namespace OptimalCuts.Tree
{
    public class AndNode : CompositeNode
    {
        public AndNode(Node c1, Node c2) : base(c1, c2)
        {
        }

        public override Node Arrange(Piece p)
        {
            // FIXME: Returns an array of all possibilities, disregarding fit factor entirely.
            double f1 = _c1.FitFactor(p);
            double f2 = _c2.FitFactor(p);

            if (f1 == 0 && f2 == 0)
            {
                return null;
            }
            else if (f1 >= f2)
            {
                return new AndNode(_c1.Arrange(p), _c2);
            }
            else if (f2 > f1)
            {
                return new AndNode(_c1, _c2.Arrange(p));
            }

            return null;
        }

        public override Panel[] GetPanels()
        {
            Panel[] c1Panels = _c1.GetPanels();
            Panel[] c2Panels = _c2.GetPanels();

            Panel[] panels = new Panel[c1Panels.Length + c2Panels.Length];

            Array.Copy(c1Panels, 0, panels, 0, c1Panels.Length);
            Array.Copy(c2Panels, 0, panels, c1Panels.Length, c2Panels.Length);

            return panels;
        }

        public override string ToString()
        {
            return $"( {_c1} AND {_c2})";
        }
    }
}