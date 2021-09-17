using System;

namespace OptimalCuts.Tree
{
    public abstract class CompositeNode : Node
    {
        public Node _c1;
        public Node _c2;

        public CompositeNode(Node c1, Node c2)
        {
            _c1 = c1;
            _c2 = c2;
        }

        public override double FitFactor(Piece p)
        {
            return Math.Max(_c1.FitFactor(p), _c2.FitFactor(p));
        }
    }
}