using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Graphs.GraphsFast
{
    public class GraphFastUndirected : GraphFast
    {
        public GraphFastUndirected() { }

        public override List<int> Neighbors(int node)
        {
            return this.NeighborsOut(node);
        }

        public override List<int> NeighborsIn(int node)
        {
            return this.NeighborsOut(node);
        }

        public override int NodeDegree(int node)
        {
            return this.NodeDegreeIn(node);
        }

        public override int NodeDegreeIn(int node)
        {
            return this.NodeDegreeIn(node);
        }

        protected override void OnEdgeAdd(int node1, int node2)
        {
            this.Network[node1].Add(node2);
            this.Network[node2].Add(node1);

            this.NumberOfEdges += 2;
        }

        protected override void OnEdgeRemove(int node1, int node2)
        {
            this.Network[node1].Remove(node2);
            this.Network[node2].Remove(node1);

            this.NumberOfEdges -= 2;
        }
    }
}
