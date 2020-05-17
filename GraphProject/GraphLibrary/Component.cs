using System;
using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using GraphLibrary;

namespace GraphLibrary
{
    public class Component
    {
        /// <summary>
        /// Returns True if the graph is connected, false otherwise.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>True if the graph is connected, false otherwise.</returns>
        /// <raises>GraphLibraryNotImplemented: – If graph is directed.</raises>
        /// <note>For undirected graphs only</note>
        public Boolean IsConnected(BaseGraph graph)
        {
            if (graph.Edges.Count == 0)
            {
                throw new NotImplementedException("Connectivity is undefined for null graph.");
            }

            List<int> connected = new List<int>();
            List<Tuple<int, int, int?>>bfs = new Traversal().BreadthFirstSearchAll(graph);

            return bfs.Count == graph.NumberOfNodes;
        }

        /// <summary>
        /// Returns the number of connected components.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Number of connected components</returns>
        /// <note>For undirected graphs only</note>
        public int NumberConectedComponents(BaseGraph graph)
        {
            List<HashSet<int>> listOfCcomponents = ConnectedComponents(graph).ToList();
            return listOfCcomponents.Count;
        }

        /// <summary>
        /// Generate connected components
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Yields sets of nodes, one for each component of graph.</returns>
        public IEnumerable<HashSet<int>> ConnectedComponents(BaseGraph graph)
        {
            HashSet<int> seen = new HashSet<int>();

            foreach (int v in graph.Nodes)
            {
                if (!seen.Contains(v))
                {
                    HashSet<int> c = new HashSet<int>(FastBfs(graph, v).ToList<int>());
                    yield return c;

                    foreach (int n in c){
                        seen.Add(n);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the set of nodes in the component of graph containing node n
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        /// <returns>A set of nodes in the component of G containing node n</returns>
        /// <note>For undirected graphs only</note>
        public HashSet<int> NodeConnectedComponent(BaseGraph graph, int n)
        {
            return new HashSet<int>(FastBfs(graph, n).ToList());
        }

        /// <summary>
        /// Generate weakly connected components of graph.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Yields sets of nodes, one for each weakly connected component of G</returns>
        public IEnumerable<HashSet<int>> WeaklyConnectedComponents(BaseGraph graph)
        {
            return ConnectedComponents(graph);
        }

        /// <summary>
        /// Test directed graph for weak connectivity.
        /// A directed graph is weakly connected if and only if the graph is connected when the direction of the edge between nodes is ignored.
        /// Note that if a graph is strongly connected, it is by definition weakly connected as well.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>True if the graph is weakly connected, False otherwise.</returns>
        public Boolean IsWeaklyConnected(BaseGraph graph)
        {
            if (graph.Nodes.Count == 0)
            {
                throw new NotImplementedException("Connectivity is undefined for the null graph.");
            }

            List<HashSet<int>> components = WeaklyConnectedComponents(graph).ToList<HashSet<int>>();
            return (components[0].Count == graph.Nodes.Count);
        }

        /// <summary>
        /// Returns the number of weakly connected components in graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Number of weakly connected components</returns>
        public int NumberWeaklyConectedComponents(BaseGraph graph)
        {
            List<HashSet<int>> listOfCcomponents = WeaklyConnectedComponents(graph).ToList();
            return listOfCcomponents.Count;
        }

        /// <summary>
        /// Generate nodes in strongly connected components of graph
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Yields sets of nodes, one for each strongly connected component of G</returns>
        public IEnumerable<HashSet<int>> StronglyConnectedComponents(BaseGraph graph)
        {
            Dictionary<int, int> preorder = new Dictionary<int, int>();
            Dictionary<int, int> lowlink = new Dictionary<int, int>();
            HashSet<int> scc_found = new HashSet<int>();
            Queue<int> scc_queue = new Queue<int>();
            int i = 0;
            int lastAdded;
            int lastSCCQueue = -1;

            foreach (int source in graph.Nodes)
            {
                if (!scc_found.Contains(source))
                {
                    Queue<int> queue = new Queue<int>();
                    queue.Enqueue(source);
                    lastAdded = source;

                    while (queue.Count != 0)
                    {
                        int v = lastAdded;
                        if (!preorder.ContainsKey(v))
                        {
                            i += 1;
                            preorder[v] = i;
                        }
                        bool done = true;
                        foreach (int w in graph.NeighborsOut(v)){
                            if (!preorder.ContainsKey(w))
                            {
                                queue.Enqueue(w);
                                lastAdded = w;
                                done = false;
                                break;
                            }
                        }
                        if (done)
                        {
                            lowlink[v] = preorder[v];
                            foreach (int w in graph.NeighborsOut(v))
                            {
                                if (!scc_found.Contains(w))
                                {
                                    if (preorder[w] > preorder[v])
                                        lowlink[v] = Math.Min(lowlink[v], lowlink[w]);
                                    else
                                        lowlink[v] = Math.Min(lowlink[v], preorder[w]);
                                }
                            }
                            queue.Dequeue();
                            if (lowlink[v] == preorder[v])
                            {
                                HashSet<int> scc = new HashSet<int>();
                                scc.Add(v);
                                while (scc_queue.Count != 0 && preorder[lastSCCQueue] > preorder[v]){
                                    int k = scc_queue.Dequeue();
                                    scc.Add(k);
                                }
                                foreach (int c in scc)
                                {
                                    scc_found.Add(c);
                                }
                                yield return scc;
                            }
                            else
                            {
                                scc_queue.Enqueue(v);
                                lastSCCQueue = v;
                            }
                        }
                            
                    }
                }
            }


        }

        /// <summary>
        /// A fast BFS node generator
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="sourceNode"></param>
        /// <returns>BFS nodes</returns>
        private IEnumerable<int> FastBfs(BaseGraph graph, int sourceNode)
        {
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> nextLevel = new HashSet<int>();
            nextLevel.Add(sourceNode);

            while (nextLevel.Count != 0)
            {
                HashSet<int> thisLevel = nextLevel;
                nextLevel = new HashSet<int>();
                foreach (int v in thisLevel)
                {
                    if (!seen.Contains(v))
                    {
                        yield return v;

                        seen.Add(v);
                        foreach (int neighbor in graph.Neighbors(v))
                        {
                            nextLevel.Add(neighbor);
                        }
                    }
                }
            }
        }

    }
}
