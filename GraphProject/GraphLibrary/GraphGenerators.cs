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
        /// Each node is connected to each other node and to it's self
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
                    graph.EdgeAdd(node1, node2);

            return graph;
        }

        /// <summary>
        /// 
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
    }
}
