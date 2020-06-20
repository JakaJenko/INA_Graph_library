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
    public class Clustering
    {
        /// <summary>
        /// Compute the number of triangles. Finds the number of triangles that include a node as one vertex.
        /// </summary>
        /// <param name="g">A BaseGraph graph</param>
        /// <param name="nodes">A List of nodes, optional. Compute triangles for nodes in this container.</param>
        /// <returns>Number of triangles keyed by node label.</returns>
        public Dictionary<int, int> Triangles(BaseGraph g, List<int> nodes = null)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            if (nodes != null && nodes.Count == 1)
            {
                result[nodes[0]] = TrianglesAndDegreeIter(g, nodes).Take(1).ElementAt(0).Item3 / 2;
                return result;
            }

            foreach(Tuple<int, int, int, List<int>> tuple in TrianglesAndDegreeIter(g, nodes))
            {
                result[tuple.Item1] = tuple.Item3 / 2;
            }
            return result;
        }

        /// <summary>
        /// Compute graph transitivity, the fraction of all possible triangles present in G.
        ///
        /// Possible triangles are identified by the number of "triads"
        /// (two edges with a shared vertex).
        //  The transitivity is
        //  T = 3\frac{\#triangles}{\#triads}.
        /// </summary>
        /// <param name="g">BaseGraph graph</param>
        /// <returns>Float - transitivity</returns>
        public double Transitivity(BaseGraph g)
        {
            List<int> trianglesList = new List<int>();
            List<int> contriList = new List<int>();

            foreach (Tuple<int, int, int, List<int>> tuple in TrianglesAndDegreeIter(g))
            {
                trianglesList.Add(tuple.Item3);
                contriList.Add(tuple.Item2 * (tuple.Item2 - 1));
            }
            double triangles = trianglesList.Sum();
            double contri = contriList.Sum();

            if (triangles == 0)
                return 0.0;
            else
                return triangles / contri;
        }

        /// <summary>
        /// Compute the clustering coefficient for nodes. Implemented only for unweighted and undirected graphs.
        /// </summary>
        /// <param name="graph">Basegraph graph</param>
        /// <param name="nodes">List of nodes - optional</param>
        /// <returns>Dictionary of clustering coefficients at specified nodes</returns>
        public Dictionary<int, double> ClusteringCoefficient(BaseGraph graph, List<int> nodes=null)
        {
            Dictionary<int, double> clusterc = new Dictionary<int, double>();
            foreach (Tuple<int, int, int, List<int>> tuple in TrianglesAndDegreeIter(graph, nodes))
            {
                int v = tuple.Item1;
                double d = tuple.Item2;
                double t = tuple.Item3;
                if (t == 0)
                    clusterc[v] = 0;
                else
                    clusterc[v] = t / (d * (d - 1));
            }
            
            return clusterc;
        }

        /// <summary>
        /// Compute the average clustering coefficient for the graph G. The clustering coefficient for the graph is the average,
        /// </summary>
        /// <param name="graph">BaseGraph graph</param>
        /// <param name="nodes">List of nodes</param>
        /// <param name="countZeros">If False include only the nodes with nonzero clustering in the average.</param>
        /// <returns>Double: Avergae clustering</returns>
        public double AverageClustering(BaseGraph graph, List<int> nodes = null, bool countZeros=true)
        {
            Dictionary<int, double> c = ClusteringCoefficient(graph, nodes);
            List<double> cValues = c.Values.ToList<double>();
            if (!countZeros)
            {
                cValues = cValues.Where(i => i != 0).ToList();
            }
            return (double)cValues.Sum() / (double)cValues.Count;
        }

        /// <summary>
        /// Compute the generalized degree for nodes. For each node, the generalized degree shows how many edges of given triangle multiplicity the node is connected to.The triangle multiplicity of an edge is the number of triangles an edge participates in.
        /// </summary>
        /// <param name="g">BaseGraph</param>
        /// <param name="nodes">List of nodes</param>
        /// <returns>Generalized degree of specified nodes. The Counter is keyed by edge triangle multiplicity.</returns>
        public Dictionary<int, List<int>> GeneralizedDegree(BaseGraph graph, List<int> nodes=null)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            foreach (Tuple<int, int, int, List<int>> tuple in TrianglesAndDegreeIter(graph, nodes))
            {
                int v = tuple.Item1;
                double d = tuple.Item2;
                double t = tuple.Item3;
                List<int> gd = tuple.Item4;
                result[v] = gd;
            }
            return result;
        }

        /// <summary>
        /// This double counts triangles so you may want to divide by 2. See degree(), triangles() and generalized_degree() for definitions and details.
        /// </summary>
        /// <param name="g"></param>
        /// <returns>Return an iterator of (node, degree, triangles, generalized degree)</returns>
        private IEnumerable<Tuple<int,int,int,List<int>>> TrianglesAndDegreeIter(BaseGraph g, List<int> nodes=null)
        {
            if (nodes != null)
            {
                foreach (int v in nodes)
                {
                    HashSet<int> vs = new HashSet<int>(g.NeighborsOut(v));
                    List<int> gen_degree = new List<int>();
                    foreach (int w in vs)
                    {
                        gen_degree.Add(vs.Intersect(g.NeighborsOut(w)).ToList<int>().Count);
                    }
                    int ntriangles = gen_degree.Sum();
                    yield return new Tuple<int, int, int, List<int>>(v, vs.Count, ntriangles, gen_degree);
                }
            }
            else
            {
                foreach(int v in g.Nodes)
                {
                    HashSet<int> vs = new HashSet<int>(g.NeighborsOut(v));
                    List<int> gen_degree = new List<int>();
                    foreach(int w in vs)
                    {
                        gen_degree.Add(vs.Intersect(g.NeighborsOut(w)).ToList<int>().Count);
                    }
                    int ntriangles = gen_degree.Sum();
                    yield return new Tuple<int, int, int, List<int>>(v, vs.Count, ntriangles, gen_degree);
                }
            }
        }
    }
}
