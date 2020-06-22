using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary.Graphs.GraphsFast
{
    /// <summary>
    /// GraphFast undirected
    /// </summary>
    public class GraphFastUndirected : GraphFast
    {
        public GraphFastUndirected() { }

        /// <summary>
        /// Gets list of eges
        /// </summary>
        public override List<Tuple<int, int>> Edges
        {
            get
            {
                var edges = new HashSet<Tuple<int, int>>();

                foreach (KeyValuePair<int, HashSet<int>> entry in this.Network)
                {
                    foreach (int connection in entry.Value)
                    {
                        if(entry.Key < connection)
                            edges.Add(new Tuple<int, int>(entry.Key, connection));
                        else
                            edges.Add(new Tuple<int, int>(connection, entry.Key));
                    }
                }

                return edges.ToList();
            }
        }

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
        /// Number of in and out neighbors of all nodes
        /// On GraphFastUndirected <see cref="NodeDegrees()"/>, <see cref="NodeDegreesIn()"/> and <see cref="GraphsFast.GraphFast.NodeDegreesOut()"/> are the same
        /// </summary>
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
        /// On GraphFastUndirected <see cref="NodeDegree(int)"/>, <see cref="NodeDegreeIn(int)"/> and <see cref="GraphsFast.GraphFast.NodeDegreeOut(int)"/> are the same
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in neighbors</returns>
        public override int NodeDegreeIn(int node)
        {
            return this.NodeDegreeOut(node);
        }

        /// <summary>
        /// Number of in neighbors of all nodes
        /// On GraphFastUndirected <see cref="NodeDegrees()"/>, <see cref="NodeDegreesIn()"/> and <see cref="GraphsFast.GraphFast.NodeDegreesOut()"/> are the same
        /// </summary>
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
        /// and edge from node2 to node1
        /// </summary>
        /// <param name="node1">Node from</param>
        /// <param name="node2">Node to</param>
        protected override void OnEdgeAdd(int node1, int node2)
        {
            this.Network[node1].Add(node2);
            this.Network[node2].Add(node1);
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
        }
    }
}
