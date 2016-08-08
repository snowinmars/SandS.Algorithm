using SandS.Algorithm.Library.Graph;
using Xunit;

namespace SandS.Algorithm.Library.GraphTest
{
    public class GraphTreeUnitTest
    {
        public class GraphUnitTest
        {
            //      0
            //      |
            //      1
            //      |
            //      2
            //      |
            //      3
            //     / \
            //    4   5
            //        |
            //        6
            //       / \
            //      7   8

            private static BidirectionalGraphNode<object> NewGraphNode
            {
                get
                {
                    return new BidirectionalGraphNode<object>(new object());
                }
            }

            private static GraphTree<BidirectionalGraphNode<object>, object> NewGraph
            {
                get
                {
                    GraphTree<BidirectionalGraphNode<object>, object> graph = new GraphTree<BidirectionalGraphNode<object>, object>();

                    BidirectionalGraphNode<object> node0 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node1 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node2 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node3 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node4 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node5 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node6 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node7 = new BidirectionalGraphNode<object>(new object());
                    BidirectionalGraphNode<object> node8 = new BidirectionalGraphNode<object>(new object());

                    graph.Connect(node0, node1);
                    graph.Connect(node1, node2);
                    graph.Connect(node2, node3);
                    graph.Connect(node3, node8);
                    graph.Connect(node3, node4);
                    graph.Connect(node4, node5);
                    graph.Connect(node5, node6);
                    graph.Connect(node5, node7);

                    graph.AddNode(node0);

                    return graph;
                }
            }

            #region correct

            [Fact]
            public void CreateTestGraphMustNotThrowArgExc()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph.ShallowClone();
                Assert.False(graph == null);
            }

            #endregion correct

            #region cycles

            [Fact]
            public void OriginalGraphMustNotContainsCycle()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(false, graph.IsCycle());
            }

            [Fact]
            public void ModifyedOriginalGraphMustContainsCycleVer1()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //        |
                //        6
                //       / \
                //      7---8
                //        ^
                //       new

                Assert.Equal(false, graph.IsCycle());

                graph.State = GraphState.CanBeCycle;

                graph.Connect(graph.Nodes[7], graph.Nodes[8]);

                Assert.Equal(true, graph.IsCycle());
            }

            [Fact]
            public void ModifyedOriginalGraphMustContainsCycleVer2()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //    |   |
                //    |   6
                //new \  / \
                //      7   8

                Assert.Equal(false, graph.IsCycle());

                graph.State = GraphState.CanBeCycle;

                graph.Connect(graph.Nodes[4], graph.Nodes[7]);

                Assert.Equal(true, graph.IsCycle());
            }

            #endregion cycles

            #region loops

            [Fact]
            public void OriginalGraphMustNotContainsLoops()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(false, graph.IsLooped());
            }

            [Fact]
            public void CycleAndLoopIsDifferent()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(false, graph.IsCycle());
                Assert.Equal(false, graph.IsLooped());

                graph.State = GraphState.CanBeLooped;

                graph.Connect(graph.Nodes[6], graph.Nodes[6]);

                Assert.Equal(false, graph.IsCycle());
                Assert.Equal(true, graph.IsLooped());
            }

            [Fact]
            //      0
            //      |
            //      1
            //      |
            //      2
            //      |
            //      3
            //     / \
            //    4   5
            //        |
            //        6
            //       / \
            //      7   8
            public void ModifyedOriginalGraphMustContainsLoop()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(false, graph.IsLooped());

                graph.State = GraphState.CanBeLooped;

                graph.Connect(graph.Nodes[6], graph.Nodes[6]);

                Assert.Equal(true, graph.IsLooped());
            }

            #endregion loops

            #region connectivity

            [Fact]
            public void OriginalGraphMustBeConnectivity()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(false, graph.IsNonConnectivity());
            }

            [Fact]
            public void ModifyedOriginalGraphMustBeConnectivity()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //        |
                //        6
                //       / \
                //      7   8
                //          |
                //          9 < new

                Assert.Equal(false, graph.IsNonConnectivity());

                graph.State = GraphState.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);
                graph.Connect(graph.Nodes[7], graph.Nodes[9]);

                Assert.Equal(false, graph.IsNonConnectivity());
            }

            [Fact]
            public void ModifyedOriginalGraphMustNotBeConnectivity()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //        |
                //        6
                //       / \
                //      7   8
                //
                //          9 < new

                Assert.Equal(false, graph.IsNonConnectivity());

                graph.State = GraphState.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);

                Assert.Equal(true, graph.IsNonConnectivity());
            }

            #endregion connectivity

            #region routeBetween

            [Fact]
            public void OriginalGraphMustHaveRouteBetweenNodes()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                Assert.Equal(true, graph.IsRouteBetween(graph.Nodes[2], graph.Nodes[5]));
            }

            [Fact]
            public void ModifyedOriginalGraphMustHaveRouteBetweenNodes()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //        |
                //        6
                //       / \
                //      7   8
                //          | < new
                //          9 < new

                graph.State = GraphState.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);
                graph.Connect(graph.Nodes[7], graph.Nodes[9]);

                Assert.Equal(true, graph.IsRouteBetween(graph.Nodes[9], graph.Nodes[6]));
            }

            [Fact]
            public void NonConnectivityGraphMustNotHaveRouteBetweenNonConnectiviedNodes()
            {
                GraphTree<BidirectionalGraphNode<object>, object> graph = NewGraph;

                //      0
                //      |
                //      1
                //      |
                //      2
                //      |
                //      3
                //     / \
                //    4   5
                //        |
                //        6
                //       / \
                //      7   8
                //
                //          9 < new

                graph.State = GraphState.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);

                Assert.Equal(false, graph.IsRouteBetween(graph.Nodes[9], graph.Nodes[6]));
            }

            #endregion routeBetween
        }
    }
}