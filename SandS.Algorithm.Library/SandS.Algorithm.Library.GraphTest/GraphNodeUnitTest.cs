using SandS.Algorithm.Library.GraphNamespace;
using Xunit;

namespace SandS.Algorithm.Library.GraphTestNamespace
{
    public class GraphNodeUnitTest
    {
        public BidirectionalGraphNode<object> NewGraphNode
        {
            get
            {
                BidirectionalGraphNode<object> node = new BidirectionalGraphNode<object>(new object())
                {
                    Color = GraphNodeColor.Grey
                };

                BidirectionalGraphNode<object> node0 = new BidirectionalGraphNode<object>(new object());
                BidirectionalGraphNode<object> node1 = new BidirectionalGraphNode<object>(new object());
                BidirectionalGraphNode<object> node2 = new BidirectionalGraphNode<object>(new object());

                node.Children.Add(node0);
                node.Children.Add(node1);
                node.Children.Add(node2);

                return node;
            }
        }

        #region correct

        [Fact]
        public void CreateTestGraphNodeMustNotThrowArgExc()
        {
            BidirectionalGraphNode<object> node = this.NewGraphNode;
        }

        [Fact]
        public void CtorMustInit()
        {
            BidirectionalGraphNode<object> node = new BidirectionalGraphNode<object>(new object());

            Assert.NotNull(node.Body);
            Assert.NotNull(node.Children);

            Assert.Equal(0, node.Children.Count);
        }

        #endregion correct
    }
}