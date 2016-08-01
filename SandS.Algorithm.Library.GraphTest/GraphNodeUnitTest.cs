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
        public GraphNode<> NewGraphNode
        {
            get
            {
                GraphNode node = new GraphNode()
                {
                    Color = Color.Grey
                };

                GraphNode node0 = new GraphNode();
                GraphNode node1 = new GraphNode();
                GraphNode node2 = new GraphNode();

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
            GraphNode node = this.NewGraphNode;
        }

        #endregion correct
    }
}
