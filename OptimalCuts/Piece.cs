using System;

namespace OptimalCuts
{
    public class Piece
    {
        public double _length { get; set; }
        public double _width { get; set; }

        public Piece(double length, double width)
        {
            _length = length;
            _width = width;
        }

        public int HashCode()
        {
            const int prime = 31;
            int result = 1;
            long temp;

            temp = BitConverter.DoubleToInt64Bits(_length);

            result = prime * result + (int)((ulong)temp ^ ((ulong)temp >> 32));

            temp = BitConverter.DoubleToInt64Bits(_width);

            result = prime * result + (int)((ulong)temp ^ ((ulong)temp >> 32));

            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                Console.WriteLine("Oops?");
                return false;
            }

            Piece other = (Piece)obj;

            if (BitConverter.DoubleToInt64Bits(_length) != BitConverter.DoubleToInt64Bits(other._length))
            {
                return false;
            }

            if (BitConverter.DoubleToInt64Bits(_width) != BitConverter.DoubleToInt64Bits(other._width))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"Piece {HashCode()} ({_width},{_length})";
        }
    }
}