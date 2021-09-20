namespace OptimalCuts
{
    public class Settings
    {
        private double _length;
        private double _width;

        public void SetSheetSize(double length, double width)
        {
            _length = length;
            _width = width;
        }

        public double GetLength()
        {
            return _length;
        }

        public double GetWidth()
        {
            return _width;
        }
    }
}