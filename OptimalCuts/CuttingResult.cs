using System.Collections.Generic;

namespace OptimalCuts
{
    public class CuttingResult
    {
        private List<Sheet> _sheets;
        private List<Piece> _notFits;

        public CuttingResult(List<Sheet> sheets, List<Piece> notFits)
        {
            _sheets = sheets;
            _notFits = notFits;
        }

        public int GetNumSheets()
        {
            return _sheets.Count;
        }

        public Sheet GetSheet(int i)
        {
            return _sheets[i];
        }

        public List<Piece> GetNotFits()
        {
            return _notFits;
        }
    }
}