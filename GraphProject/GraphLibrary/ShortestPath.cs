using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    public class ShortestPath
    {
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
