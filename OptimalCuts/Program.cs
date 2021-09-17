using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OptimalCuts
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stockList = new StreamReader("stockList.json");
            var stockContent = stockList.ReadToEnd();
            dynamic stockJson = JObject.Parse(stockContent);

            Sheet[] sheets = new Sheet[stockJson.quantity];

            for (int i = 0; i < sheets.Length; i++)
            {
                // TODO: Move the ToObject<type> calls into the constructor (replacing with TryParse too).
                // TODO: No longer using .Parse methods, TryParse no longer appropriate. Use other validations!
                sheets[i] = new Sheet(stockJson.stocks[i].length.ToObject<double>(),
                    stockJson.stocks[i].width.ToObject<double>(),
                    stockJson.stocks[i].quantity.ToObject<int>(),
                    i);
            }

            using var panelList = new StreamReader("panelList.json");
            var panelContent = panelList.ReadToEnd();
            dynamic panelJson = JObject.Parse(panelContent);

            Panel[] panels = new Panel[panelJson.quantity];

            for (int i = 0; i < panels.Length; i++)
            {
                panels[i] = new Panel(panelJson.panels[i].length.ToObject<double>(),
                    panelJson.panels[i].width.ToObject<double>(), panelJson.panels[i].quantity.ToObject<int>(),
                    panelJson.panels[i].canTurn.ToObject<bool>(),
                    i);
            }

            Console.WriteLine("From a stock of {");
            foreach (var sheet in sheets) Console.WriteLine(sheet);
            Console.WriteLine("}");

            Console.WriteLine("User wants cuts to result in {");
            foreach (var panel in panels) Console.WriteLine(panel);
            Console.WriteLine("}");


            SheetCutter sheetCutter = new SheetCutter(sheets, panels);
            sheetCutter.SetBasicStructure();

        }
    }
}