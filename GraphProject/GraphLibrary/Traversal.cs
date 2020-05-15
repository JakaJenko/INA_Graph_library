using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace GraphLibrary
{
    public class Traversal
    {
        /// <summary>
        /// Returns all nodes with distance from nodeSource and predecesor based on Breadth first search
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodeSource">Node from where the BFS algorithm starts</param>
        /// <param name="depth">Up to which depth (distance) the nodes are returned</param>
        /// <returns>Returns nodes with distances and it's predecesor</returns>
        public List<Tuple<int, int, int?>> BreadthFirstSearchAll(BaseGraph graph, int nodeSource = 0, int? nodeEnd = null, int ? maxDepth = null)
        {
            return this.BreadthFirstSearch(graph, nodeSource, nodeEnd, maxDepth).ToList();
        }

        /// <summary>
        /// Returns node with node with distance from nodeSource and predecesor based on Breadth first search
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodeSource">Node from where the BFS algorithm starts</param>
        /// <param name="depth">Up to which depth (distance) the nodes are returned</param>
        /// <returns>Returns node by node with distance and it's predecesor</returns>
        public IEnumerable<Tuple<int, int, int?>> BreadthFirstSearch(BaseGraph graph, int nodeSource = 0, int? nodeEnd = null, int? maxDepth = null)
        {
            int currentDepth = 0;
            int firstNodeOfNextDepth = nodeSource;

            int nodeIndex = -1;

            yield return new Tuple<int, int, int?>(nodeSource, currentDepth, null);

            // Visited vertices
            bool[] visited = new bool[graph.NumberOfEdges];

            // Queue of nodes
            Queue<int> queue = new Queue<int>();

            visited[nodeSource] = true;
            queue.Enqueue(nodeSource);

            while (queue.Count != 0)
            {
                nodeIndex++;
                int node = queue.Dequeue();
                

                var nodeNeighbors = graph.NeighborsOut(node);

                foreach (var neighbor in nodeNeighbors)
                {
                    if (!visited[neighbor])
                    {
                        if (node == firstNodeOfNextDepth)
                        {
                            firstNodeOfNextDepth = neighbor;
                            currentDepth++;

                            if (currentDepth > maxDepth)
                                yield break;
                        }

                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        yield return new Tuple<int, int, int?>(neighbor, currentDepth, nodeIndex);

                        if(nodeEnd.HasValue)
                            if(neighbor == nodeEnd)
                                yield break;
                    }
                }
            }
        }
    }
}
