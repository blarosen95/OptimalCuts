namespace OptimalCuts
{
    public class Panel
    {
        public int _panelId { get; set; }
        public double _length { get; set; }
        public double _width { get; set; }
        public int _quantity { get; set; }
        public bool _isCanTurn { get; set; }

        public Panel(double length, double width, int quantity, bool isCanTurn, int panelId)
        {
            _panelId = panelId;
            _length = length;
            _width = width;
            _quantity = quantity;
            _isCanTurn = isCanTurn;
        }

        public void Deconstruct(out double length, out double width, out int quantity, out bool isCanTurn)
        {
            length = _length;
            width = _width;
            quantity = _quantity;
            isCanTurn = _isCanTurn;
        }

        public override string ToString()
        {
            return $"{_quantity} {(_quantity > 1 ? "panels" : "panel")}, {_length} long and {_width} wide.";
        }
    }
}