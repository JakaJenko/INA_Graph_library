using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Graphs.GraphsFast
{
    public class GraphFastDirected : GraphFast
    {
        public GraphFastDirected() {}

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
        /// Returns number of in neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in neighbors</returns>
        public override int NodeDegreeIn(int node)
        {
            return this.NeighborsIn(node).Count;
        }

        /// <summary>
        /// Adds edge from node1 to node2
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeAdd(int node1, int node2)
        {
            this.Network[node1].Add(node2);
            this.NumberOfEdges++;
        }

        /// <summary>
        /// Removes edge from node1 to node2
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeRemove(int node1, int node2)
        {
            this.Network[node1].Remove(node2);
            this.NumberOfEdges--;
        }
    }
}
