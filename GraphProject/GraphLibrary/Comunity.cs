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
    public class Comunity
    {
        /// <summary>
        /// Finds communities in a graph using the Girvan–Newman method.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Yields tuples of sets of nodes in G. Each set of nodes is a community, each tuple is a sequence of communities at a particular level of the algorithm.</returns>
        /// <note>The Girvan–Newman algorithm detects communities by progressively
        /// removing edges from the original graph.The algorithm removes the
        /// "most valuable" edge, traditionally the edge with the highest
        /// betweenness centrality, at each step.As the graph breaks down into
        /// pieces, the tightly knit community structure is exposed and the
        /// result can be depicted as a dendrogram.</note>
        public IEnumerable<Tuple<HashSet<int>, HashSet<int>>> GirwanNewman(BaseGraph graph)
        {
            throw new NotImplementedException("Function not implemented");

            if (graph.NumberOfEdges == 0)
            {
                //yield return new Tuple<HashSet<int>>(new Component().ConnectedComponents(graph)));
                yield break;
            }
        }

        /// <summary>
        /// Returns the LFR benchmark graph.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="tau1"></param>
        /// <param name="tau2"></param>
        /// <param name="mu"></param>
        /// <param name="averageDegree"></param>
        /// <param name="minDegree"></param>
        /// <param name="maxDegree"></param>
        /// <param name="minCommunity"></param>
        /// <param name="MaxCommunity"></param>
        /// <param name="tol"></param>
        /// <param name="max_iters"></param>
        /// <param name="seed"></param>
        /// <returns>The LFR benchmark graph generated according to the specified parameters</returns>
        public BaseGraph LFRBenchmarkGraph(int n, float tau1, float tau2, float mu, float averageDegree, int minDegree, int maxDegree, int minCommunity, int MaxCommunity, float tol, int max_iters, int seed)
        {
            throw new NotImplementedException("Function not implemented");
        }

    }
}
