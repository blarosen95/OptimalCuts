using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using OptimalCuts.extensions;

namespace OptimalCuts
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new Settings();
            // settings.SetSheetSize(108.0, 8.0);
            // settings.SetSheetSize(10008.0, 8.0);


            // FirstOptimizer firstOptimizer = new FirstOptimizer();
            // firstOptimizer.Setup(settings);

            // firstOptimizer.AddPiece(17.0, 4);
            // firstOptimizer.AddPiece(20.0, 4);
            // firstOptimizer.AddPiece(17.0, 4);
            // firstOptimizer.AddPiece(17.0, 4);
            // firstOptimizer.AddPiece(20.0, 4);
            // firstOptimizer.AddPiece(17.0, 4);

            SecondOptimizer secondOptimizer = new SecondOptimizer();
            secondOptimizer.AddSetting(72, 4);
            secondOptimizer.AddSetting(72, 4);
            secondOptimizer.AddSetting(72, 4);
            secondOptimizer.AddSetting(80, 4);
            secondOptimizer.AddSetting(80, 4);
            secondOptimizer.AddSetting(108, 4);
            secondOptimizer.AddSetting(108, 4);

            secondOptimizer.AddPiece(8, 4);
            secondOptimizer.AddPiece(8, 4);
            secondOptimizer.AddPiece(8, 4);
            secondOptimizer.AddPiece(8, 4);

            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);
            secondOptimizer.AddPiece(20, 4);

            secondOptimizer.AddPiece(48, 4);
            secondOptimizer.AddPiece(48, 4);

            secondOptimizer.AddPiece(33, 4);
            secondOptimizer.AddPiece(33, 4);
            secondOptimizer.AddPiece(33, 4);
            secondOptimizer.AddPiece(33, 4);

            secondOptimizer.AddPiece(17, 4);
            secondOptimizer.AddPiece(17, 4);
            secondOptimizer.AddPiece(17, 4);
            secondOptimizer.AddPiece(17, 4);

            secondOptimizer.AddPiece(44, 4);
            secondOptimizer.AddPiece(44, 4);

            // CuttingResult cuttingResult = firstOptimizer.Calc();
            // CuttingResult cuttingResult = secondOptimizer.Calc();
            CuttingResult cuttingResult = secondOptimizer.CalcAlt();

            Panel[] panels = cuttingResult.GetSheet(0).GetPanels();

            Console.WriteLine($"First Sheet is {cuttingResult.GetSheet(0)}");

            // TODO: The following only works with single sheet quantities (which is the current state of progress for this program too)
            // foreach (var panel in panels)
            panels.Each((panel, i) =>
            {
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(panel);

                Console.WriteLine();

                // First, if this is a waste piece, let the user know:
                // TODO: The current concept of waste is limited... Once more than one sheet is possible, FIXME.
                // Console.WriteLine(i == firstOptimizer.GetNumPieces()
                Console.WriteLine(i == secondOptimizer.GetNumPieces()
                    ? $"Reached waste-piece at Panel #{i + 1}"
                    : $"For Panel #{i + 1}:");

                // Ensure that crosscut is needed:
                if (Math.Abs(panel._y2 - panel._y1) > 0.0f)
                {
                    Console.WriteLine(
                        $"Mark remaining Sheet for a crosscut at {panel._y2 - panel._y1} units along the length.");

                    Console.WriteLine($"Make the previously mentioned crosscut.");
                }

                // Determine if rip-cut is needed:
                if (Math.Abs(panel._x2 - panel._x1) > 0.0f)
                {
                    Console.WriteLine($"Mark cut-off for a rip cut at {panel._x2 - panel._x1} units across the width.");

                    Console.WriteLine($"Make the previously mentioned rip cut.");
                }
            });

            Console.WriteLine($"Total Settings: {secondOptimizer.GetNumStocks()}.");

            foreach (var notFit in cuttingResult.GetNotFits())
            {
                Console.WriteLine($"Could not fit: {notFit}!");
            }
            
            Console.WriteLine($"Total Sheets: {cuttingResult.GetNumSheets()}");

            // foreach (var setting in secondOptimizer.GetSettingsList())
            // {
                // Console.WriteLine($"Setting: {setting}");
            // }

            // Console.WriteLine($"Sheets: {firstOptimizer.GetNumPieces()}");
            /*
            string sheetVisA = "------------------------------------------------";
            string sheetVisB = "|                                              |";
            string sheetVisC = "|                                              |";
            string sheetVisD = "------------------------------------------------";

            string sheetVis = @"------------------------------------------------
|                                              |
|                                              |
------------------------------------------------";


            Console.WriteLine($"{sheetVis}");
            */


            // Console.WriteLine($"{string.Concat(Enumerable.Repeat("-"))}");
        }
    }
}