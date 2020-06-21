using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Graphs.GraphsFast
{
    /// <summary>
    /// GraphFast directed
    /// </summary>
    public class GraphFastDirected : GraphFast
    {
        public GraphFastDirected() {}

        /// <summary>
        /// Gets list of eges
        /// </summary>
        public override List<Tuple<int, int>> Edges
        {
            get
            {
                var edges = new List<Tuple<int, int>>();

                foreach (KeyValuePair<int, HashSet<int>> entry in this.Network)
                    foreach (int connection in entry.Value)
                        edges.Add(new Tuple<int, int>(entry.Key, connection));

                return edges;
            }
        }

        /// <summary>
        /// Returns list of in and out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in and out neighbors</returns>
        public override List<int> Neighbors(int node)
        {
            List<int> neighbors = this.NeighborsIn(node);
            neighbors.AddRange(this.NeighborsOut(node));

            return neighbors;
        }

        /// <summary>
        /// Returns list of in neighbors of a node.
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in neighbors</returns>
        public override List<int> NeighborsIn(int node)
        {
            List<int> neighborsIn = new List<int>();

            foreach (KeyValuePair<int, HashSet<int>> entry in this.Network)
                if (entry.Value.Contains(node))
                    neighborsIn.Add(entry.Key);

            return neighborsIn;
        }

        /// <summary>
        /// Returns number of in and out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in and out neighbors</returns>
        public override int NodeDegree(int node)
        {
            return this.NodeDegreeIn(node) + this.NodeDegreeOut(node);
        }

        /// <summary>
        /// Number of in and out neighbors of all nodes
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Dictionary of nodes and numbers of in and out neighbors</returns>
        public override Dictionary<int, int> NodeDegrees()
        {
            var nodeDegrees = new Dictionary<int, int>();

            foreach (var node in this.Nodes)
                nodeDegrees.Add(node, this.NodeDegree(node));

            return nodeDegrees;
        }

        /// <summary>
        /// Returns number of in neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in neighbors</returns>
        public override int NodeDegreeIn(int node)
        {
            return this.NeighborsIn(node).Count;
        }

        /// <summary>
        /// Number of in neighbors of all nodes
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Dictionary of nodes and numbers of in neighbors</returns>
        public override Dictionary<int, int> NodeDegreesIn()
        {
            var nodeDegreesIn = new Dictionary<int, int>();

            foreach (var node in this.Nodes)
                nodeDegreesIn.Add(node, this.NodeDegreeIn(node));

            return nodeDegreesIn;
        }

        /// <summary>
        /// Adds edge from node1 to node2
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeAdd(int node1, int node2)
        {
            this.Network[node1].Add(node2);
        }

        /// <summary>
        /// Removes edge from node1 to node2
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeRemove(int node1, int node2)
        {
            this.Network[node1].Remove(node2);
        }
    }
}
