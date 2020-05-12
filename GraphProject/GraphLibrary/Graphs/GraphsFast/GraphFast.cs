using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GraphLibrary.Graphs.GraphsFast
{
    /// <summary>
    /// Graph with only the basic functionality
    /// </summary>
    public abstract class GraphFast : BaseGraph
    {
        /// <summary>
        /// Property that holds graph data.
        /// Each node has list of neighbors.
        /// </summary>
        public Dictionary<int, HashSet<int>> Network { get; set; } = new Dictionary<int, HashSet<int>>();

        /// <summary>
        /// Gets list of nodes
        /// </summary>
        public override List<int> Nodes
        {
            get
            {
                return this.Network.Keys.ToList();
            }
        }

        /// <summary>
        /// Gets number of nodes
        /// </summary>
        public override int NumberOfNodes { get { return this.Network.Count; } }

        /// <summary>
        /// Gets list of edges
        /// </summary>
        public override int NumberOfEdges { get { return this.Edges.Count; } }

        /// <summary>
        /// Adds node consecutively
        /// </summary>
        public void NodeAdd()
        {
            this.Network.Add(this.NumberOfNodes, new HashSet<int>());
        }

        /// <summary>
        /// Adds node
        /// </summary>
        /// <param name="node">Node</param>
        public override void NodeAdd(int node)
        {
            this.Network.Add(node, new HashSet<int>());
        }

        /// <summary>
        /// Adds multiple nodes
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        public override void NodeAdd(List<int> nodes)
        {
            foreach (int node in nodes)
                this.NodeAdd(node);
        }

        /// <summary>
        /// Removes a node
        /// </summary>
        /// <param name="node">node</param>
        public override void NodeRemove(int node)
        {
            if (!this.Network.ContainsKey(node))
                throw new Exceptions.NodeNotInGraphException(node);

            this.Network.Remove(node);
        }

        /// <summary>
        /// Adds edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        public override void EdgeAdd(int node1, int node2)
        {
            if (!this.Network.ContainsKey(node1))
                throw new Exceptions.NodeNotInGraphException(node1);

            if (!this.Network.ContainsKey(node2))
                throw new Exceptions.NodeNotInGraphException(node2);

            this.OnEdgeAdd(node1, node2);
        }

        /// <summary>
        /// Adds multiple edges
        /// </summary>
        /// <param name="edges">List of pairs of nodes</param>
        public override void EdgeAdd(List<Tuple<int, int>> edges)
        {
            foreach (var edge in edges)
                this.EdgeAdd(edge.Item1, edge.Item2);
        }

        /// <summary>
        /// Adds edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        protected abstract void OnEdgeAdd(int node1, int node2);

        /// <summary>
        /// Removes an edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        public override void EdgeRemove(int node1, int node2)
        {
            if (!this.Network.ContainsKey(node1))
                throw new Exceptions.NodeNotInGraphException(node1);

            if (!this.Network.ContainsKey(node2))
                throw new Exceptions.NodeNotInGraphException(node2);

            this.OnEdgeRemove(node1, node2);
        }

        /// <summary>
        /// Removes an edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        protected abstract void OnEdgeRemove(int node1, int node2);

        /// <summary>
        /// Returns list of out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of out neighbors</returns>
        public override List<int> NeighborsOut(int node)
        {
            return this.Network[node].ToList();
        }

        /// <summary>
        /// Number of out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of out neighbors</returns>
        public override int NodeDegreeOut(int node)
        {
            return this.Network[node].Count();
        }

        /// <summary>
        /// Number of out neighbors of all nodes
        /// </summary>
        /// <returns>Dictionary of nodes and numbers of out neighbors</returns>
        public override Dictionary<int, int> NodeDegreesOut()
        {
            var nodeDegreesOut = new Dictionary<int, int>();

            foreach (var node in this.Nodes)
                nodeDegreesOut.Add(node, this.NodeDegreeOut(node));

            return nodeDegreesOut;
        }

        /// <summary>
        /// Creates graph from Pajek file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public override void ReadPajek(string path)
        {
            using (var file = new System.IO.StreamReader(path))
            {
                int numberOfNodesInPajek = Convert.ToInt32(file.ReadLine().Split(' ').Last());
                this.Network = new Dictionary<int, HashSet<int>>(numberOfNodesInPajek);

                while (!file.ReadLine().Contains("*"))
                {
                    this.NodeAdd();
                }

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    int node1 = Convert.ToInt32(line.Split(' ')[0]) - 1;
                    int node2 = Convert.ToInt32(line.Split(' ')[1]) - 1;

                    this.EdgeAdd(node1, node2);
                }
            }
        }

        public override void ReadEdgeList(string path)
        {
            using (var file = new System.IO.StreamReader(path))
            {
                string line;

                while (file.ReadLine()[0] == '#') { }

                while ((line = file.ReadLine()) != null)
                {
                    int node1 = Convert.ToInt32(line.Split(' ')[0]) - 1;
                    int node2 = Convert.ToInt32(line.Split(' ')[1]) - 1;

                    if (!this.Network.ContainsKey(node1))
                        this.NodeAdd(node1);

                    if (!this.Network.ContainsKey(node2))
                        this.NodeAdd(node2);

                    this.EdgeAdd(node1, node2);
                }
            }
        }
    }
}
