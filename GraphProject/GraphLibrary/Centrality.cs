using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace GraphLibrary
{
    /// <summary>
    /// Centrality
    /// </summary>
    public class Centrality
    {
        /// <summary>
        /// Computes degree centrality for all nodes.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Dictionary of node and its degree centrality.</returns>
        public Dictionary<int, int> DegreeCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegrees();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var key in centralities.Keys)
                centralities[key] *= s;

            return centralities;
        }

        /// <summary>
        /// Computes degree centrality for one node.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Returns node's degree centrality.</returns>
        public float DegreeCentrality(BaseGraph graph, int node)
        {
            return graph.NodeDegree(node) * (1 / (graph.NumberOfNodes - 1));
        }

        /// <summary>
        /// Computes in-degree centrality for all nodes.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Dictionary of node and its in-degree centrality.</returns>
        public Dictionary<int, int> DegreeInCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegreesIn();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var key in centralities.Keys)
                centralities[key] *= s;

            return centralities;
        }

        /// <summary>
        /// Computes in-degree centrality for one node.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Returns node's in-degree centrality.</returns>
        public float DegreeInCentrality(BaseGraph graph, int node)
        {
            return graph.NodeDegreeIn(node) * (1 / (graph.NumberOfNodes - 1));
        }

        /// <summary>
        /// Computes out-degree centrality for all nodes.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Dictionary of node and its out-degree centrality.</returns>
        public Dictionary<int, int> DegreeOutCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegreesOut();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var key in centralities.Keys)
                centralities[key] *= s;

            return centralities;
        }

        /// <summary>
        /// Computes out-degree centrality for one node.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <returns>Returns node's out-degree centrality.</returns>
        public float DegreeOutCentrality(BaseGraph graph, int node)
        {
            return graph.NodeDegreeOut(node) * (1 / (graph.NumberOfNodes - 1));
        }

        /// <summary>
        /// Betweeness centrality.
        /// </summary>
        public void BetweenessCentrality()
        {
            //za vsak node najdi najkrajšo pot do vseh ostalih nodov
            //če ima weighte na nodih tu uporabi Dijkstro
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closeness centrality.
        /// </summary>
        public void ClosenessCentrality()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// PageRank
        /// </summary>
        public void Pagerank()
        {
            throw new NotImplementedException();
        }
    }
}
