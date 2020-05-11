using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Graphs.GraphsFast
{
    public class GraphFastUndirected : GraphFast
    {
        public GraphFastUndirected() { }

        /// <summary>
        /// Returns list of in and out neighbors of a node
        /// On GraphFastUndirected <see cref="Neighbors(int)"/>, <see cref="NeighborsIn(int)"/> and <see cref="GraphsFast.GraphFast.NeighborsOut(int)"/> are the same
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in and out neighbors</returns>
        public override List<int> Neighbors(int node)
        {
            return this.NeighborsOut(node);
        }

        /// <summary>
        /// Returns list of in neighbors of a node.
        /// On GraphFastUndirected <see cref="Neighbors(int)"/>, <see cref="NeighborsIn(int)"/> and <see cref="GraphsFast.GraphFast.NeighborsOut(int)"/> are the same
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in neighbors</returns>
        public override List<int> NeighborsIn(int node)
        {
            return this.NeighborsOut(node);
        }

        /// <summary>
        /// Returns number of in and out neighbors of a node
        /// On GraphFastUndirected <see cref="NodeDegree(int)"/>, <see cref="NodeDegreeIn(int)"/> and <see cref="GraphsFast.GraphFast.NodeDegreeOut(int)"/> are the same
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in and out neighbors</returns>
        public override int NodeDegree(int node)
        {
            return this.NodeDegreeOut(node);
        }

        /// <summary>
        /// Returns number of in neighbors of a node
        /// On GraphFastUndirected <see cref="NodeDegree(int)"/>, <see cref="NodeDegreeIn(int)"/> and <see cref="GraphsFast.GraphFast.NodeDegreeOut(int)"/> are the same
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in neighbors</returns>
        public override int NodeDegreeIn(int node)
        {
            return this.NodeDegreeOut(node);
        }

        /// <summary>
        /// Adds edge from node1 to node2
        /// and edge from node2 to node1
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeAdd(int node1, int node2)
        {
            this.Network[node1].Add(node2);
            this.Network[node2].Add(node1);

            this.NumberOfEdges += 2;
        }

        /// <summary>
        /// Removes edge from node1 to node2
        /// and edge from node2 to node1
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeRemove(int node1, int node2)
        {
            this.Network[node1].Remove(node2);
            this.Network[node2].Remove(node1);

            this.NumberOfEdges -= 2;
        }
    }
}
