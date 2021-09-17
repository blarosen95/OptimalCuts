using System;

namespace OptimalCuts
{
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
}