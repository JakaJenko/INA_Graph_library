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

        public BaseGraph CompleteGraph(int numberOfNodes, GraphTypes graphType = GraphTypes.GraphFastDirected)
        {
            BaseGraph graph = graphFactory.GetGraph(graphType);

            List<int> nodes = Enumerable.Range(0, numberOfNodes).ToList();
            graph.NodeAdd(nodes);

            foreach (int node1 in graph.Nodes)
                foreach (int node2 in graph.Nodes)
                    graph.EdgeAdd(node1, node2);

            return graph;
        }
        
        public BaseGraph ErdosEenyiGraph(int numberOfNodes, double propabilityOfEdge, GraphTypes graphType = GraphTypes.GraphFastDirected)
        {
            BaseGraph graph = graphFactory.GetGraph(graphType);

            List<int> nodes = Enumerable.Range(0, numberOfNodes).ToList();
            graph.NodeAdd(nodes);

            Random rnd = new Random();

            var edges = new Helpers().Combinations(nodes);

            foreach (IList<int> edge in edges)
                if (rnd.NextDouble() < propabilityOfEdge)
                    graph.EdgeAdd(edge[0], edge[1]);

            return graph;
        }
    }
}
