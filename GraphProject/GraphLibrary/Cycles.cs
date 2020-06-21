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
    public class Cycles
    {
        /// <summary>
        /// Returns a list of cycles which form a basis for cycles of G.
        /// 
        ///     A basis for cycles of a network is a minimal collection of
        /// cycles such that any cycle in the network can be written
        /// as a sum of cycles in the basis.Here summation of cycles
        /// is defined as "exclusive or" of the edges.Cycle bases are
        /// useful, e.g.when deriving equations for electric circuits
        /// using Kirchhoff's Laws.
        /// </summary>
        /// <param name="graph">BaseGraph</param>
        /// <returns>A list of cycle lists.  Each cycle list is a list of nodes which forms a cycle(loop) in G.</returns>
        public HashSet<List<int>> CycleBasis(BaseGraph graph)
        {
            List<int> gnodes = new List<int>(graph.Nodes);
            HashSet<List<int>> cycles = new HashSet<List<int>>();
            int root = -1;
            while(gnodes.Count > 0)
            {
                if(root == -1)
                {
                    root = gnodes[0];
                    gnodes.RemoveAt(0);
                }
                Stack<int> stack = new Stack<int>();
                stack.Push(root);
                Dictionary<int, int> pred = new Dictionary<int, int>();
                pred[root] = root;
                Dictionary<int, HashSet<int>> used = new Dictionary<int, HashSet<int>>();
                used[root] = new HashSet<int>();
                while(stack.Count > 0)
                {
                    int z = stack.Pop();
                    HashSet<int> zused = used[z];
                    foreach(int nbr in graph.Neighbors(z))
                    {
                        if (!used.ContainsKey(nbr))
                        {
                            pred[nbr] = z;
                            stack.Push(nbr);
                            used[nbr] = new HashSet<int>();
                            used[nbr].Add(z);
                        }else if(nbr == z)
                        {
                            cycles.Add(new List<int>(z));
                        }else if(!zused.Contains(nbr))
                        {
                            HashSet<int> pn = used[nbr];
                            List<int> cycle = new List<int>();
                            cycle.Add(nbr);
                            cycle.Add(z);
                            int p = pred[z];
                            while (!pn.Contains(p))
                            {
                                cycle.Add(p);
                                p = pred[p];
                            }
                            cycle.Add(p);
                            cycles.Add(cycle);
                            used[nbr].Add(z);
                        }
                    }
                }
                foreach (int key in pred.Keys)
                    gnodes.Remove(key);
                root = -1;
            }
            return cycles;
        }
    }
}
