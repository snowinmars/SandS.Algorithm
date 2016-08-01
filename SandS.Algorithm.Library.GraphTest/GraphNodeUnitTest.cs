using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.Graph;
using Xunit;

namespace SandS.Algorithm.Library.GraphTest
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

        #endregion correct
    }
}
