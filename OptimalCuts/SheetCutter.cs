using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using OptimalCuts.extensions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OptimalCuts
{
    /*
    public class SheetCutter
    {
        private Sheet[] _sheets;
        private Panel[] _panels;
        private List<List<Panel>> _panelsInSheets;
        private dynamic _BasicFitsDataStructure = new JObject();


        public SheetCutter(Sheet[] sheets, Panel[] panels)
        {
            _sheets = sheets;
            _panels = panels;
        }

        public void SetBasicStructure()
        {
            Console.WriteLine($"There are {_sheets.Length} {(_sheets.Length > 1 ? "sheets" : "sheet")}");
            _BasicFitsDataStructure.Sheets = new JArray();

            _sheets.Each((sheet, i) =>
            {
                sheet.Deconstruct(out var sheetLength, out var sheetWidth, out var sheetQuantity);

                // TODO: Refactor such that the following line is added inside a JObject "Sheet"!
                _BasicFitsDataStructure.Sheets.Add(JToken.Parse(JsonSerializer.Serialize(sheet)));

                Console.WriteLine(_BasicFitsDataStructure.Sheets[i].GetType());

                // _BasicFitsDataStructure.Sheets[i].Panels = new JObject(); // TODO: WORKING LINE HERE!!!!!!
                _BasicFitsDataStructure.Sheets[i].Panels = new JArray();

                foreach (var panel in _panels)
                {
                    panel.Deconstruct(out var panelLength, out var panelWidth, out var panelQuantity,
                        out var panelCanTurn);

                    if (panelLength <= sheetLength)
                    {
                        // Console.WriteLine($"DEBUG. Current Sheet is long enough to fit current Panel");
                        if (panelWidth <= sheetWidth)
                        {
                            // Console.WriteLine($"DEBUG. Current Sheet is wide enough to fit current Panel. Storing it.");

                            // TODO: Refactor such that this is added inside a JObject named "Panel"!!!!
                            _BasicFitsDataStructure.Sheets[i].Panels.Add(JToken.Parse(JsonSerializer.Serialize(panel)));
                        }
                    }
                }
            });

            Console.WriteLine(_BasicFitsDataStructure);
        }

        public void SetOptimalCutListLinear()
        {
            Console.WriteLine("TODO");
           // 
           //   TODO: Loop on each Sheet first
           //    Each time a panel fits the length:
           //        subtract that length from the sheet (remembering which quantity number it was cut from)...
           //
        }
    }
    */
}