
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Graphs
{
    /// <summary>
    /// Base class for graphs
    /// </summary>
    public abstract class BaseGraph
    {
        /// <summary>
        /// Gets list of nodes
        /// </summary>
        public abstract List<int> Nodes { get; }

        /// <summary>
        /// Gets list of eges
        /// </summary>
        public abstract List<Tuple<int, int>> Edges { get; }

        /// <summary>
        /// Gets number of nodes
        /// </summary>
        public abstract int NumberOfNodes { get; }
        
        /// <summary>
        /// Gets list of edges
        /// </summary>
        public abstract int NumberOfEdges { get; }


        /// <summary>
        /// Creates graph from Pajek file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public abstract void ReadPajek(string path);

        /// <summary>
        /// Creates graph from Edge list file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public abstract void ReadEdgeList(string path);


        /// <summary>
        /// Adds node
        /// </summary>
        /// <param name="node">Node</param>
        public abstract void NodeAdd(int node);

        /// <summary>
        /// Adds multiple nodes
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        public abstract void NodeAdd(List<int> nodes);

        /// <summary>
        /// Removes a node
        /// </summary>
        /// <param name="node">node</param>
        public abstract void NodeRemove(int node);


        /// <summary>
        /// Adds edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        public abstract void EdgeAdd(int node1, int node2);

        /// <summary>
        /// Adds multiple edges
        /// </summary>
        /// <param name="edges">List of pairs of nodes</param>
        public abstract void EdgeAdd(List<Tuple<int, int>> edges);

        /// <summary>
        /// Removes an edge between two nodes
        /// </summary>
        /// <param name="node1">Node one</param>
        /// <param name="node2">Node two</param>
        public abstract void EdgeRemove(int node1, int node2);


        /// <summary>
        /// Returns list of in and out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in and out neighbors</returns>
        public abstract List<int> Neighbors(int node);

        /// <summary>
        /// Returns list of in neighbors of a node
        /// List of in-nodes where in-node -> node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of in neighbors</returns>
        public abstract List<int> NeighborsIn(int node);

        /// <summary>
        /// Returns list of out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>List of out neighbors</returns>
        public abstract List<int> NeighborsOut(int node);


        /// <summary>
        /// Number of in and out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in and out neighbors</returns>
        public abstract int NodeDegree(int node);

        /// <summary>
        /// Number of in neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of in neighbors</returns>
        public abstract int NodeDegreeIn(int node);

        /// <summary>
        /// Number of out neighbors of a node
        /// </summary>
        /// <param name="node">Node</param>
        /// <returns>Number of out neighbors</returns>
        public abstract int NodeDegreeOut(int node);
    }
}
