using System;
using SandS.Algorithm.Library.GraphNamespace;
using Xunit;

namespace SandS.Algorithm.Library.GraphTestNamespace
{
    public class GraphTreeUnitTest
    {
        public class GraphUnitTest
        {
            private static GraphNode<int> NewGraphNode
            {
                get
                {
                    return new GraphNode<int>(new int());
                }
            }

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

            private static GraphTree<GraphNode<int>, int> NewGraph
            {
                get
                {
                    GraphTree<GraphNode<int>, int> graph = new GraphTree<GraphNode<int>, int>();

                    GraphNode<int> node0 = new GraphNode<int>(0);
                    GraphNode<int> node1 = new GraphNode<int>(1);
                    GraphNode<int> node2 = new GraphNode<int>(2);
                    GraphNode<int> node3 = new GraphNode<int>(3);
                    GraphNode<int> node4 = new GraphNode<int>(4);
                    GraphNode<int> node5 = new GraphNode<int>(5);
                    GraphNode<int> node6 = new GraphNode<int>(6);
                    GraphNode<int> node7 = new GraphNode<int>(7);
                    GraphNode<int> node8 = new GraphNode<int>(8);

                    graph.Connect(node0, node1);
                    graph.Connect(node1, node2);
                    graph.Connect(node2, node3);
                    graph.Connect(node3, node5);
                    graph.Connect(node3, node4);
                    graph.Connect(node5, node6);
                    graph.Connect(node6, node7);
                    graph.Connect(node6, node8);

                    graph.AddNode(node0);

                    return graph;
                }
            }

            #region correct

            [Fact]
            public void CreateTestGraphMustNotThrowArgExc()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph.ShallowClone();
                Assert.False(graph == null);
            }

            #endregion correct

            #region cycles

            [Fact]
            public void OriginalGraphMustNotContainsCycle()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph;

                Assert.Equal(false, graph.IsCycle());
            }

            [Fact]
            public void ModifyedOriginalGraphMustContainsCycleVer1()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

                Assert.Equal(false, graph.IsLooped());
            }

            [Fact]
            public void CycleAndLoopIsDifferent()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

                Assert.Equal(false, graph.IsNonConnectivity());
            }

            [Fact]
            public void ModifyedOriginalGraphMustBeConnectivity()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

                Assert.Equal(true, graph.IsRouteBetween(graph.Nodes[2], graph.Nodes[5]));
            }

            [Fact]
            public void ModifyedOriginalGraphMustHaveRouteBetweenNodes()
            {
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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
                GraphTree<GraphNode<int>, int> graph = NewGraph;

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

            #region binary

            [Fact]
            public void BinaryGraphTreeMustBeBinary_Positive()
            {
                GraphTree<GraphNode<int>, int> graph = new GraphTree<GraphNode<int>, int>();
                graph.State |= GraphState.IsBinary;

                GraphNode<int> head = new GraphNode<int>(0);
                GraphNode<int> lhs = new GraphNode<int>(1);
                GraphNode<int> rhs = new GraphNode<int>(2);

                graph.Connect(head,lhs);
                graph.Connect(head, rhs);

                graph.AddNode(head);
            }

            [Fact]
            public void BinaryGraphTreeMustBeBinary_Negative()
            {
                GraphTree<GraphNode<int>, int> graph = new GraphTree<GraphNode<int>, int>();
                graph.State |= GraphState.IsBinary;

                GraphNode<int> head = new GraphNode<int>(0);
                GraphNode<int> lhs = new GraphNode<int>(1);
                GraphNode<int> rhs = new GraphNode<int>(2);
                GraphNode<int> otherNode = new GraphNode<int>(2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    graph.Connect(head, lhs);
                    graph.Connect(head, rhs);
                    graph.Connect(head, otherNode);

                    graph.AddNode(head);
                });
            }

            #endregion
        }
    }
}