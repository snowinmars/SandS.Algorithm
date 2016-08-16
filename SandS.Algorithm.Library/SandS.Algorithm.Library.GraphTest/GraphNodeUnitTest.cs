using SandS.Algorithm.Library.GraphNamespace;
using Xunit;

namespace SandS.Algorithm.Library.GraphTestNamespace
{
    public class GraphNodeUnitTest
    {
        public GraphNode<object> NewGraphNode
        {
            get
            {
                GraphNode<object> node = new GraphNode<object>(new object())
                {
                    Color = GraphNodeColor.Grey
                };

                GraphNode<object> node0 = new GraphNode<object>(new object());
                GraphNode<object> node1 = new GraphNode<object>(new object());
                GraphNode<object> node2 = new GraphNode<object>(new object());

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
            GraphNode<object> node = this.NewGraphNode;
        }

        [Fact]
        public void CtorMustInit()
        {
            GraphNode<object> node = new GraphNode<object>(new object());

            Assert.NotNull(node.Body);
            Assert.NotNull(node.Children);

            Assert.Equal(0, node.Children.Count);
        }

        #endregion correct
    }
}