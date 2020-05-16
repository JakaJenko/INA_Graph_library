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
        public List<Tuple<int, int, int?>> BreadthFirstSearchAll(BaseGraph graph, int nodeSource = 0, int? nodeEnd = null, int? maxDepth = null)
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
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        yield return new Tuple<int, int, int?>(neighbor, currentDepth, nodeIndex);

                        if (nodeEnd.HasValue)
                            if (neighbor == nodeEnd)
                                yield break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns all nodes with distance from nodeSource and predecesor based on Depth first search
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodeSource">Node from where the DFS algorithm starts</param>
        /// <param name="depth">Up to which depth (distance) the nodes are returned</param>
        /// <returns>Returns nodes with distances and it's predecesor</returns>
        public List<Tuple<int, int, int?>> DepthFirstSearchAll(BaseGraph graph, int nodeSource = 0, int? nodeEnd = null, int maxDepth = int.MaxValue)
        {
            return this.DepthFirstSearch(graph, nodeSource, nodeEnd, maxDepth).ToList();
        }

        /// <summary>
        /// Returns node with node with distance from nodeSource and predecesor based on Breadth first search
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="nodeSource">Node from where the BFS algorithm starts</param>
        /// <param name="depth">Up to which depth (distance) the nodes are returned</param>
        /// <returns>Returns node by node with distance and it's predecesor</returns>
        public IEnumerable<Tuple<int, int, int?>> DepthFirstSearch(BaseGraph graph, int nodeSource = 0, int? nodeEnd = null, int maxDepth = int.MaxValue)
        {
            if (graph.NumberOfNodes == 0)
            {
                yield break;
            }

            int nodeIndex = -1;

            // Visited vertices
            bool[] visited = new bool[graph.NumberOfEdges];

            // Stack of nodes and their depths
            Stack<Tuple<int,int>> stack = new Stack<Tuple<int,int>>();

            visited[nodeSource] = true;
            stack.Push(new Tuple<int,int>(nodeSource, 0));

            while (stack.Count != 0)
            {
                (int node , int depth) = stack.Pop();
                visited[node] = true;

                yield return new Tuple<int, int, int?>(node, depth, nodeIndex);

                nodeIndex++;

                if (nodeEnd.HasValue)
                    if (node == nodeEnd)
                        yield break;

                var nodeNeighbors = graph.NeighborsOut(node);
                
                foreach (var neighbor in nodeNeighbors)
                {
                    if (!visited[neighbor] && depth + 1 < maxDepth)
                    {
                        stack.Push(new Tuple<int, int>(neighbor, depth + 1));
                    }
                }
            }
        }
    }
}
