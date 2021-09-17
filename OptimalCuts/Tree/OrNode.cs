namespace OptimalCuts.Tree
{
    public class OrNode : CompositeNode
    {
        public OrNode(Node c1, Node c2) : base(c1, c2)
        {
        }

        public override Node Arrange(Piece p)
        {
            // TODO: return an array of Nodes (similar to AndNode)...

            double f1 = _c1.FitFactor(p);
            double f2 = _c2.FitFactor(p);

            if (f1 == 0 && f2 == 0)
            {
                return null;
            }
            else if (f1 >= f2)
            {
                return _c1.Arrange(p); // Discards _c2.
            }
            else if (f2 > f1)
            {
                return _c2.Arrange(p);
            }

            return null;
        }

        public override Panel[] GetPanels()
        {
            return _c1.GetPanels();
        }

        public override string ToString()
        {
            return $"( {_c1} OR {_c2})";
        }
    }
}