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
    public class DistanceMeasures
    {

        /// <summary>
        /// Returns the effective diameter of the graph G.
        /// The diameter is the maximum eccentricity.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="p">percentile</param>
        /// <returns>Returns integer the diameter of the graph G.</returns>
        public static int EffectiveDiameter(BaseGraph graph, double p = 0.9)
        {
            var distancesPerNode = NetworkDistances(graph);
            List<short> distances = new List<short>();

            for (int i = 0; i < distancesPerNode.Count; i++)
            {
                for (int j = i + 1; j < distancesPerNode.Count; j++)
                {
                    distances.Add(distancesPerNode[i][j].Value);
                }

                distancesPerNode[i] = null;
            }

            distances.Sort();
            int perc = Convert.ToInt32(distances.Count * p);

            return distances[perc];
        }

        /// <summary>
        /// Returns network distances for
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Returns a list of distances.</returns>
        public static List<List<short?>> NetworkDistances(BaseGraph graph)
        {

            List<List<short?>> distances = new List<List<short?>>();

            foreach (int node in graph.Nodes)
            {
                distances.Add(UndirectedDistances(graph, node));
            }

            return distances;
        }

        /// <summary>
        /// UndirectedDistances is a supporting function used by Diamter
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private static List<short?> UndirectedDistances(BaseGraph graph, int node)
        {
            short?[] distances = new short?[graph.NumberOfNodes];

            Queue<int> queue = new Queue<int>();

            distances[node] = 0;
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                int i = queue.Dequeue();

                foreach (int neighbour in graph.Neighbors(i))
                {
                    if (distances[neighbour] == null)
                    {
                        distances[neighbour] = checked((short)(distances[i] + 1));
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return distances.ToList();
        }

    }
}
