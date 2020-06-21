using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    /// <summary>
    /// Shortest path finder
    /// </summary>
    public class ShortestPath
    {
        /// <summary>
        /// Finds shortes path, given the start and end nodes.
        /// </summary>
        /// <param name="graph">BaseGraph graph.</param>
        /// <param name="nodeSource">Source node.</param>
        /// <param name="nodeEnd">End node</param>
        /// <returns>Returns the shortest path from start to end node.</returns>
        public List<int> ShorthestPath(BaseGraph graph, int nodeSource, int nodeEnd)
        {
            var traversal = new Traversal();

            List<int> path = new List<int>();

            var bfs = traversal.BreadthFirstSearchAll(graph, nodeSource, nodeEnd);

            var nodeData = bfs.Last();

            if (nodeEnd != nodeData.Item1)
                throw new Exception();

            while (nodeData.Item3.HasValue)
            {
                path.Add(nodeData.Item1);
                nodeData = bfs[nodeData.Item3.Value];
            }

            path.Add(nodeSource);
            path.Reverse();

            return path;
        }
    }
}
