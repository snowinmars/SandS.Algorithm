using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            private static GraphNode NewGraphNode
            {
                get
                {
                    return new GraphNode();
                }
            }

            private static Graph<GraphNode> NewGraph
            {
                get
                {
                    Graph<GraphNode> graph = new Graph<GraphNode>();

                    GraphNode node0 = new GraphNode();
                    GraphNode node1 = new GraphNode();
                    GraphNode node2 = new GraphNode();
                    GraphNode node3 = new GraphNode();
                    GraphNode node4 = new GraphNode();
                    GraphNode node5 = new GraphNode();
                    GraphNode node6 = new GraphNode();
                    GraphNode node7 = new GraphNode();
                    GraphNode node8 = new GraphNode();

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
                Graph<GraphNode> graph = NewGraph.ShallowClone();
                Assert.IsFalse(graph == null);
            }

            #endregion correct

            #region cycles

            [Fact]
            public void OriginalGraphMustNotContainsCycle()
            {
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(false, graph.IsCycle());
            }

            [Fact]
            public void ModifyedOriginalGraphMustContainsCycleVer1()
            {
                Graph<GraphNode> graph = NewGraph;

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

                Assert.AreEqual(false, graph.IsCycle());

                graph.State = State.CanBeCycle;

                graph.Connect(graph.Nodes[7], graph.Nodes[8]);

                Assert.AreEqual(true, graph.IsCycle());
            }

            [Fact]
            public void ModifyedOriginalGraphMustContainsCycleVer2()
            {
                Graph<GraphNode> graph = NewGraph;

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

                Assert.AreEqual(false, graph.IsCycle());

                graph.State = State.CanBeCycle;

                graph.Connect(graph.Nodes[4], graph.Nodes[7]);

                Assert.AreEqual(true, graph.IsCycle());
            }

            #endregion cycles

            #region loops

            [Fact]
            public void OriginalGraphMustNotContainsLoops()
            {
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(false, graph.IsLooped());
            }

            [Fact]
            public void CycleAndLoopIsDifferent()
            {
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(false, graph.IsCycle());
                Assert.AreEqual(false, graph.IsLooped());

                graph.State = State.CanBeLooped;

                graph.Connect(graph.Nodes[6], graph.Nodes[6]);

                Assert.AreEqual(false, graph.IsCycle());
                Assert.AreEqual(true, graph.IsLooped());
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
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(false, graph.IsLooped());

                graph.State = State.CanBeLooped;

                graph.Connect(graph.Nodes[6], graph.Nodes[6]);

                Assert.AreEqual(true, graph.IsLooped());
            }

            #endregion loops

            #region connectivity

            [Fact]
            public void OriginalGraphMustBeConnectivity()
            {
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(false, graph.IsNonConnectivity());
            }

            [Fact]
            public void ModifyedOriginalGraphMustBeConnectivity()
            {
                Graph<GraphNode> graph = NewGraph;

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

                Assert.AreEqual(false, graph.IsNonConnectivity());

                graph.State = State.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);
                graph.Connect(graph.Nodes[7], graph.Nodes[9]);

                Assert.AreEqual(false, graph.IsNonConnectivity());
            }

            [Fact]
            public void ModifyedOriginalGraphMustNotBeConnectivity()
            {
                Graph<GraphNode> graph = NewGraph;

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

                Assert.AreEqual(false, graph.IsNonConnectivity());

                graph.State = State.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);

                Assert.AreEqual(true, graph.IsNonConnectivity());
            }

            #endregion connectivity

            #region routeBetween

            [Fact]
            public void OriginalGraphMustHaveRouteBetweenNodes()
            {
                Graph<GraphNode> graph = NewGraph;

                Assert.AreEqual(true, graph.IsRouteBetween(graph.Nodes[2], graph.Nodes[5]));
            }

            [Fact]
            public void ModifyedOriginalGraphMustHaveRouteBetweenNodes()
            {
                Graph<GraphNode> graph = NewGraph;

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

                graph.State = State.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);
                graph.Connect(graph.Nodes[7], graph.Nodes[9]);

                Assert.AreEqual(true, graph.IsRouteBetween(graph.Nodes[9], graph.Nodes[6]));
            }

            [Fact]
            public void NonConnectivityGraphMustNotHaveRouteBetweenNonConnectiviedNodes()
            {
                Graph<GraphNode> graph = NewGraph;

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

                graph.State = State.CanBeNonConnectivly;

                graph.AddNode(NewGraphNode);

                Assert.AreEqual(false, graph.IsRouteBetween(graph.Nodes[9], graph.Nodes[6]));
            }

            #endregion routeBetween
        }
    }
