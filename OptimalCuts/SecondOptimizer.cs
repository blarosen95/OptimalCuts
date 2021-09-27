using System;
using System.Collections.Generic;

namespace OptimalCuts
{
    public class SecondOptimizer
    {
        // private Settings[] _settingsArray;
        private List<Settings> _settingsList;
        private List<Piece> _pieces;

        private int _testIterator;

        public SecondOptimizer()
        {
            _pieces = new List<Piece>();
            _settingsList = new List<Settings>();

            _testIterator = 0;
        }

        // TODO #1: Refactor Settings as a whole in order to reflect it being "Stock" instead.
        // TODO #2: Eventually have a "User" entity that maps to their own, individual "Stock"s.
        // public void AddSetting(Settings settings)
        public void AddSetting(double length, double width)
        {
            // _settingsList.Add(settings);
            Settings settings = new Settings();
            settings.SetSheetSize(length, width);
            _settingsList.Add(settings);
        }

        public void AddPiece(double length, double width)
        {
            _pieces.Add(new Piece(length, width));
        }

        public int GetNumPieces()
        {
            return _pieces.Count;
        }

        public int GetNumStocks()
        {
            return _settingsList.Count;
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
            List<Piece> notFitting = new List<Piece>(); // TODO: 

            // TODO: Root cause of issue where it only fits for one Setting item, but also has zero notFitting pieces:
            // We are only able to get inside the sheetWithMaxFactor == null conditionals once, each.
            // Solutions:
            // * Look at having a list of sheetWithMaxFactor items.
            // * This will need to line up (in terms of index and size) with: _settingsList
            foreach (Piece piece in _pieces)
            {
                foreach (Settings setting in _settingsList)
                {
                    // Console.WriteLine($"Current Settings iterator is: {setting} And we are in Piece: {piece}");
                    foreach (Sheet sheet in sheets)
                    {
                        // Console.WriteLine($"Current Sheets iterator is: {sheet}");
                        double factor = sheet.FitFactor(piece);
                        // Console.WriteLine($"Factor is now: {factor}.");

                        if (sheetWithMaximumFactor == null || factor > maximumFactor)
                        {
                            maximumFactor = factor;
                            Console.WriteLine($"Maximum Factor is now: {maximumFactor}");
                            sheetWithMaximumFactor = sheet;
                        }
                    }

                    if (sheetWithMaximumFactor == null)
                    {
                        // TODO: the following line requires we are efficiently going through the sheets in our list of settings
                        // if (Sheet.Fits(_settingsList, piece))
                        if (Sheet.Fits(setting, piece))
                        {
                            // TODO: the following line requires we are efficiently going through the sheets in our list of settings
                            // sheetWithMaximumFactor = new Sheet(_settingsList);
                            Console.WriteLine($"Sheet fits setting piece!");
                            sheetWithMaximumFactor =
                                new Sheet(setting); // TODO: We should move to next Setting here I think
                            sheets.Add(sheetWithMaximumFactor);
                        }
                        else
                        {
                            Console.WriteLine($"Adding Piece: {piece} to notFitting!");
                            notFitting.Add(piece);
                            continue;
                        }
                    }

                    sheetWithMaximumFactor.Arrange(piece);
                    // TODO: Following line is for debug purposes.
                    CheckResult(sheets);
                }
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

        public CuttingResult CalcAlt()
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
            List<Piece> notFitting = new List<Piece>(); // TODO: 

            // TODO: Root cause of issue where it only fits for one Setting item, but also has zero notFitting pieces:
            // We are only able to get inside the sheetWithMaxFactor == null conditionals once, each.
            // Solutions:
            // * Look at having a list of sheetWithMaxFactor items.
            // * This will need to line up (in terms of index and size) with: _settingsList
            foreach (var setting in _settingsList)
            {
                foreach (Piece piece in _pieces)
                {
                    // foreach (Settings setting in _settingsList)
                    // {
                    foreach (Sheet sheet in sheets)
                    {
                        // Console.WriteLine($"Current Sheets iterator is: {sheet}");
                        double factor = sheet.FitFactor(piece);
                        // Console.WriteLine($"Factor is now: {factor}.");

                        if (sheetWithMaximumFactor == null || factor > maximumFactor)
                        {
                            maximumFactor = factor;
                            // Console.WriteLine($"Maximum Factor is now: {maximumFactor}");
                            sheetWithMaximumFactor = sheet;
                        }
                    }

                    if (sheetWithMaximumFactor == null)
                    {
                        // TODO: the following line requires we are efficiently going through the sheets in our list of settings
                        // if (Sheet.Fits(_settingsList, piece))
                        if (Sheet.Fits(setting, piece))
                        {
                            // TODO: the following line requires we are efficiently going through the sheets in our list of settings
                            // sheetWithMaximumFactor = new Sheet(_settingsList);
                            Console.WriteLine($"Sheet fits setting piece!");
                            sheetWithMaximumFactor =
                                new Sheet(setting); // TODO: We should move to next Setting here I think
                            sheets.Add(sheetWithMaximumFactor);
                        }
                        else
                        {
                            Console.WriteLine($"Adding Piece: {piece} to notFitting!");
                            notFitting.Add(piece);
                            continue;
                        }
                    }

                    sheetWithMaximumFactor.Arrange(piece);
                    // TODO: Following line is for debug purposes.
                    CheckResult(sheets);
                }

                // Ending this iteration of the foreach loop against _settingsList. As such, track it:
                _testIterator++;
                Console.WriteLine($"Iteration now at: {_testIterator}");
            }

            return new CuttingResult(sheets, notFitting);
        }
    }
}