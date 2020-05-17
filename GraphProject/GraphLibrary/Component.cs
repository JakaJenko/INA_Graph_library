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

            if (bfs.Count == graph.NumberOfNodes)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        /// A fast BFS node generator
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="sourceNode"></param>
        /// <returns>BFS nodes</returns>
        /// <note>For undirected graphs only</note>
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
