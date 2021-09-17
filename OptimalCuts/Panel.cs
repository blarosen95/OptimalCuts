namespace OptimalCuts
{
    public class Panel
    {
        public double _x1;
        public double _y1;
        public double _x2;
        public double _y2;
        private bool _free;

        public Panel(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public void SetFree(bool free)
        {
            _free = free;
        }

        public bool IsFree()
        {
            return _free;
        }

        public override string ToString()
        {
            return $"[{_x1},{_y1},{_x2},{_y2},{_free}]";
        }
    }
    // public class Panel
    // {
    //     public int _panelId { get; set; }
    //     public double _length { get; set; }
    //     public double _width { get; set; }
    //     public int _quantity { get; set; }
    //     public bool _isCanTurn { get; set; }
    //
    //     public Panel(double length, double width, int quantity, bool isCanTurn, int panelId)
    //     {
    //         _panelId = panelId;
    //         _length = length;
    //         _width = width;
    //         _quantity = quantity;
    //         _isCanTurn = isCanTurn;
    //     }
    //
    //     public void Deconstruct(out double length, out double width, out int quantity, out bool isCanTurn)
    //     {
    //         length = _length;
    //         width = _width;
    //         quantity = _quantity;
    //         isCanTurn = _isCanTurn;
    //     }
    //
    //     public override string ToString()
    //     {
    //         return $"{_quantity} {(_quantity > 1 ? "panels" : "panel")}, {_length} long and {_width} wide.";
    //     }
    // }
}