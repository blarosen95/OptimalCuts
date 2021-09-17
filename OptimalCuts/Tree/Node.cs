namespace OptimalCuts.Tree
{
    public abstract class Node
    {
        public abstract double FitFactor(Piece p);

        public bool Fits(Piece p)
        {
            return FitFactor(p) > 0;
        }

        public abstract Node Arrange(Piece p);

        public abstract Panel[] GetPanels();
    }
}