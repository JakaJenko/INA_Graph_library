using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphLibrary.Graphs;


namespace GraphLibrary
{
    public class GraphGenerators
    {
        private GraphFactory graphFactory = new GraphFactory();

        /// <summary>
        /// Returns complete graph
        /// Each node is connected to each other node
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes in generated graph. Higher than 0</param>
        /// <param name="graphType">Graph type, defaults to <see cref="GraphTypes.GraphFastDirected"/></param>
        /// <returns></returns>
        public BaseGraph CompleteGraph(int numberOfNodes, GraphTypes graphType = GraphTypes.GraphFastDirected)
        {
            if (numberOfNodes < 1)
                throw new ArgumentOutOfRangeException("numberOfNodes", numberOfNodes, "Value of numberOfNodes should be higher than 0");

            BaseGraph graph = graphFactory.GetGraph(graphType);

            List<int> nodes = Enumerable.Range(0, numberOfNodes).ToList();
            graph.NodeAdd(nodes);

            foreach (int node1 in graph.Nodes)
                foreach (int node2 in graph.Nodes)
                    if(node1 != node2)
                        graph.EdgeAdd(node1, node2);

            return graph;
        }

        /// <summary>
        /// Creates Erdos-Eenyi graph
        /// </summary>
        /// <param name="numberOfNodes">Number of nodes in generated graph. Higher than 0</param>
        /// <param name="propabilityOfEdge">Probability of the edge between two nodes. Value between 0 and 1</param>
        /// <param name="graphType">Graph type, defaults to <see cref="GraphTypes.GraphFastDirected"/></param>
        /// <returns></returns>
        public BaseGraph ErdosEenyiGraph(int numberOfNodes, double propabilityOfEdge, GraphTypes graphType = GraphTypes.GraphFastDirected)
        {
            if (numberOfNodes < 1)
                throw new ArgumentOutOfRangeException("numberOfNodes", numberOfNodes, "Value of numberOfNodes should be higher than 0");

            if (propabilityOfEdge < 0 || propabilityOfEdge > 1)
                throw new ArgumentOutOfRangeException("propabilityOfEdge", propabilityOfEdge, "Value of propabilityOfEdge should be between 0 and 1");


            BaseGraph graph = graphFactory.GetGraph(graphType);

            List<int> nodes = Enumerable.Range(0, numberOfNodes).ToList();
            graph.NodeAdd(nodes);

            Random rnd = new Random();

            List<Tuple<int, int>> edges;

            if(graphType == GraphTypes.GraphDirected || graphType == GraphTypes.GraphFastDirected)
                edges = new Helpers().VariationsOfEdges(nodes);
            else
                edges = new Helpers().CombinationsOfEdges(nodes);

            foreach (Tuple<int, int> edge in edges)
                if (rnd.NextDouble() < propabilityOfEdge)
                    graph.EdgeAdd(edge.Item1, edge.Item2);

            return graph;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfNodes"></param>
        /// <param name="averageNeighbors"></param>
        /// <param name="graphType"></param>
        /// <returns></returns>
        public BaseGraph PreferentialAttachmentModel(int numberOfNodes, int averageNeighbors, GraphTypes graphType = GraphTypes.GraphFastDirected)
        {
            if (numberOfNodes < 1)
                throw new ArgumentOutOfRangeException("numberOfNodes", numberOfNodes, "Value of numberOfNodes should be higher than 0");

            if (numberOfNodes-1 < averageNeighbors || averageNeighbors < 1)
                throw new ArgumentOutOfRangeException("averageNeighbors", averageNeighbors, "Value of averageNeighbors should be in range of 1 and numberOfNodes-1");


            Random rnd = new Random();

            var graph = this.CompleteGraph(averageNeighbors, graphType);
            List<Tuple<int, int>> edgeList = graph.Edges;

            if (edgeList.Count == 0)
                edgeList.Add(new Tuple<int, int>(graph.Nodes[0], graph.Nodes[0]));

            for (int node = averageNeighbors; node < numberOfNodes; node++)
            {
                graph.NodeAdd(node);

                for (int i = 0; i < averageNeighbors; i++)
                {
                    int randomEdgeId = rnd.Next(edgeList.Count);
                    int randomNodeId = rnd.Next(2);

                    Console.WriteLine(randomEdgeId + " " + randomNodeId);

                   Tuple<int, int> randomEdge = edgeList[randomEdgeId];

                    if (randomNodeId == 0)
                        graph.EdgeAdd(node, randomEdge.Item1);
                    else
                        graph.EdgeAdd(node, randomEdge.Item2);
                }

                edgeList = graph.Edges;
            }

            return graph;
        }
    }
}
