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
    /// <summary>
    /// Distance measures
    /// </summary>
    public class DistanceMeasures
    {

        /// <summary>
        /// Returns the effective diameter of the graph G.
        /// The diameter is the maximum eccentricity.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="p">percentile</param>
        /// <returns>Returns integer the diameter of the graph G.</returns>
        public int EffectiveDiameter(BaseGraph graph, double p = 0.9)
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
        /// Returns the radius of the graph G. The radius is the minimum eccentricity.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Integer radius of graph.</returns>
        public int Radius(BaseGraph graph)
        {
            Dictionary<int, int> e = Eccentricity(graph);
            return e.Values.Min();
        }

        /// <summary>
        /// Returns the center of the graph G. The center is the set of nodes with eccentricity equal to radius.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>List of nodes in center.</returns>
        public List<int> Center(BaseGraph graph)
        {
            Dictionary<int, int> e = Eccentricity(graph);
            List<int> p = new List<int>();
            int radius = e.Values.Min();

            foreach (KeyValuePair<int, int> entry in e)
            {
                if (entry.Value == radius)
                    p.Add(entry.Key);
            }
            return p;
        }

        /// <summary>
        /// Returns the periphery of the graph G.The periphery is the set of nodes with eccentricity equal to the diameter.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>List of nodes in periphery</returns>
        public List<int> Periphery(BaseGraph graph)
        {
            Dictionary<int, int> e = Eccentricity(graph);
            List<int> p = new List<int>();
            int diameter = e.Values.Max();

            foreach (KeyValuePair<int, int> entry in e)
            {
                if (entry.Value == diameter)
                    p.Add(entry.Key);
            }
            return p;
        }


        /// <summary>
        /// returns netwrok distances for undirected graph
        /// <param name="graph"></param>
        /// <returns>Returns a list of distances.</returns>
        private static List<List<short?>> NetworkDistances(BaseGraph graph)
        {

            List<List<short?>> distances = new List<List<short?>>();

            foreach (int node in graph.Nodes)
            {
                distances.Add(UndirectedDistances(graph, node));
            }

            return distances;
        }

        /// <summary>
        /// UndirectedDistances is a supporting function used by Diameter
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

        /// <summary>
        /// Eccentricity
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        private static Dictionary<int, int> Eccentricity(BaseGraph graph)
        {
            int order = graph.NumberOfNodes;

            Dictionary<int,int> e = new Dictionary<int, int>();
            for(int i=0; i<graph.NumberOfNodes; i++)
            {
                Dictionary<int,int> length = SingleSourceShortestPath(graph, i); //maybe i+1
                int l = length.Count;
                e[i] = length.Values.Max();
            }
            return e;
        }

        /// <summary>
        /// Compute the shortest path lengths from source to all reachable nodes.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="node"></param>
        /// <returns>Dict keyed by node to shortest path length to source.</returns>
        private static Dictionary<int, int> SingleSourceShortestPath(BaseGraph graph, int source)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            Dictionary<int, int> seen = new Dictionary<int, int>();
            int level = 0;
            List<int> nextLevel = new List<int>();
            List<int> thisLevel = new List<int>();
            nextLevel.Add(source);

            while(nextLevel.Count > 0)
            {
                thisLevel = nextLevel;
                nextLevel = new List<int>();
                foreach (int v in thisLevel)
                {
                    if (!seen.ContainsKey(v))
                    {
                        seen[v] = level;
                        nextLevel.AddRange(graph.Neighbors(v));
                        result.Add(v, level);
                    }
                }
                level += 1;
            }

            return result;
        }

    }
}
