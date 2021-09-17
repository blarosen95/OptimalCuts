using System.Collections;
using System.Collections.Generic;

namespace OptimalCuts
{
    public class FirstOptimizer
    {
        private List<Piece> _pieces;

        public FirstOptimizer()
        {
            _pieces = new List<Piece>();
        }

        public void AddPiece(double length, double width)
        {
            _pieces.Add(new Piece(length, width));
        }

        public CuttingResult Calc()
        {
            // Sort array, descending
            _pieces.Sort();
            // TODO: Ensure the list was just sorted in the fashion I'm expecting.

            List<Sheet> sheets = new List<Sheet>();
            
            double maximumFactor = 0;

            Sheet sheetWithMaximumFactor = null;
            
            // Begin arranging our pieces into the sheet.
            List<Piece> notFitting = new List<Piece>();

            foreach (Piece p in _pieces)
            {
                foreach (Sheet s in sheets)
                {
                    double factor = s.fitFactor(p);

                    if (sheetWithMaximumFactor == null || factor > maximumFactor)
                    {
                        maximumFactor = factor;
                        sheetWithMaximumFactor = s;
                    }
                }

                if (sheetWithMaximumFactor == null)
                {
                    if (Sheet.fits())
                }
            }
            
        }
    }
}