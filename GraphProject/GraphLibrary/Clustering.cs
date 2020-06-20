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
