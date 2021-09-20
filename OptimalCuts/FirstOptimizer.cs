using System;
using System.Collections;
using System.Collections.Generic;

namespace OptimalCuts
{
    public class FirstOptimizer
    {
        private Settings _settings;
        private List<Piece> _pieces;

        public FirstOptimizer()
        {
            _pieces = new List<Piece>();
        }

        public void Setup(Settings settings)
        {
            _settings = settings;
        }

        public void AddPiece(double length, double width)
        {
            _pieces.Add(new Piece(length, width));
        }

        public int GetNumPieces()
        {
            return _pieces.Count;
        }

        public CuttingResult Calc()
        {
            // Sort array, descending
            // _pieces.Sort();
            _pieces.Sort(new PieceSizeComparer(true));
            // _pieces.Sort(new PieceSizeComparer(false));
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
                    double factor = s.FitFactor(p);

                    if (sheetWithMaximumFactor == null || factor > maximumFactor)
                    {
                        maximumFactor = factor;
                        sheetWithMaximumFactor = s;
                    }
                }

                if (sheetWithMaximumFactor == null)
                {
                    if (Sheet.Fits(_settings, p))
                    {
                        sheetWithMaximumFactor = new Sheet(_settings);
                        sheets.Add(sheetWithMaximumFactor);
                    }
                    else
                    {
                        notFitting.Add(p);
                        continue;
                    }
                }

                sheetWithMaximumFactor.Arrange(p);
                // TODO: Remove following line, it is for debug purposes.
                CheckResult(sheets);
            }

            return new CuttingResult(sheets, notFitting);
        }

        private void CheckResult(List<Sheet> sheets)
        {
            foreach (var sheet in sheets)
            {
                Panel[] panels = sheet.GetPanels();
                CheckNoIntersection(panels);
            }
        }

        private void CheckNoIntersection(Panel[] panels)
        {
            foreach (var panel in panels)
            {
                double x11 = panel._x1;
                double x12 = panel._x2;
                double y11 = panel._y1;
                double y12 = panel._y2;

                foreach (var panel2 in panels)
                {
                    if (panel != panel2)
                    {
                        double x21 = panel2._x1;
                        double y21 = panel2._y1;

                        if (x21 > x11 && x21 < x12 && y21 > y11 && y21 < y12)
                        {
                            throw new Exception($"Overlapping {panel} and {panel2}");
                        }
                    }
                }
            }
        }
    }
}