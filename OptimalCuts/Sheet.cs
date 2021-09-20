using System;
using OptimalCuts.Tree;

namespace OptimalCuts
{
    public class Sheet
    {
        private Node _root;
        private double _length;
        private double _width;

        public Sheet(Settings settings)
        {
            _length = settings.GetLength();
            _width = settings.GetWidth();

            Panel panel = new Panel(0, 0, _width, _length);
            panel.SetFree(true);

            _root = new Leaf(panel);
        }

        public double FitFactor(Piece piece)
        {
            // Returns "this" Sheet's FitFactor as the FitFactor of its _root Node.
            return _root.FitFactor(piece);
        }

        public Node Arrange(Piece piece)
        {
            Node arranged = _root.Arrange(piece);

            if (arranged != null)
            {
                _root = arranged;
            }

            return arranged;
        }

        public Panel[] GetPanels()
        {
            return _root.GetPanels();
        }

        public override string ToString()
        {
            return $"Sheet {HashCode()} root: {{{_root}}}";
        }

        public int HashCode()
        {
            const int prime = 31;
            int result = 1;
            long temp;

            temp = BitConverter.DoubleToInt64Bits(_length);

            // FIXME: "* result" results in multiplication by 1 in every execution path; useless.
            result = prime * result + (int)((ulong)temp ^ ((ulong)temp >> 32));

            temp = BitConverter.DoubleToInt64Bits(_width);

            result = prime * result + (int)((ulong)temp ^ ((ulong)temp >> 32));

            return result;
        }

        public double GetLength()
        {
            return _length;
        }

        public double GetWidth()
        {
            return _width;
        }

        public static bool Fits(Settings settings, Piece piece)
        {
            return piece._width <= settings.GetWidth() && piece._length <= settings.GetLength();
        }
    }

    /*
    public class Sheet
    {
        public int _sheetId { get; set; }
        public double _length { get; set; }
        public double _width { get; set; }
        public int _quantity { get; set; }

        public Sheet(double length, double width, int quantity, int sheetId)
        {
            _sheetId = sheetId;
            _length = length;
            _width = width;
            _quantity = quantity;
        }

        public double fitFactor(Piece p)
        {
            
        }

        public void Deconstruct(out double length, out double width, out int quantity)
        {
            length = _length;
            width = _width;
            quantity = _quantity;
        }

        public override string ToString()
        {
            return $"{_quantity} {(_quantity > 1 ? "sheets" : "sheet")}, {_length} long and {_width} wide.";
        }
    }
    */
}