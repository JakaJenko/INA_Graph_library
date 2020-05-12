using GraphLibrary.Graphs;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace GraphLibrary
{
    public class Centrality
    {
        public Dictionary<int, int> DegreeCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegrees();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var node in centralities.Keys)
                centralities[node] *= s;

            return centralities;
        }

        public Dictionary<int, int> DegreeInCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegreesIn();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var node in centralities.Keys)
                centralities[node] *= s;

            return centralities;
        }

        public Dictionary<int, int> DegreeOutCentrality(BaseGraph graph)
        {
            var centralities = graph.NodeDegreesOut();

            int s = 1 / (graph.NumberOfNodes - 1);

            foreach (var node in centralities.Keys)
                centralities[node] *= s;

            return centralities;
        }
    }
}
