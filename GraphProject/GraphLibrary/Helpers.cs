using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    class Helpers
    {
        /// <summary>
        /// Returns combinations of edges from list of nodes.
        /// Used for undirected graphs
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        /// <returns>Returns combinations of edges from list of nodes</returns>
        /// <example>
        /// Nodes = {1, 2, 3}
        /// Result = 12, 13, 23
        /// </example>
        internal List<Tuple<int, int>> CombinationsOfEdges(List<int> nodes)
        {
            var combinations = new List<Tuple<int, int>>();

            for (int i = 0; i < nodes.Count; i++)
                for (int j = i + 1; j < nodes.Count; j++)
                    combinations.Add(new Tuple<int, int>(nodes[i], nodes[j]));

            return combinations;
        }

        /// <summary>
        /// Returns variations of edges from list of nodes.
        /// Used for directed graphs
        /// </summary>
        /// <param name="nodes">List of edges</param>
        /// <returns>Returns variations of edges from list of nodes</returns>
        /// /// <example>
        /// Nodes = {1, 2, 3}
        /// Result = 12, 13, 21, 23, 31 ,32
        /// </example>
        internal List<Tuple<int, int>> VariationsOfEdges(List<int> nodes)
        {
            var combinations = new List<Tuple<int, int>>();

            for (int i = 0; i < nodes.Count; i++)
                for (int j = 0; j < nodes.Count; j++)
                    if (i != j)
                        combinations.Add(new Tuple<int, int>(nodes[i], nodes[j]));

            return combinations;
        }
    }
}
