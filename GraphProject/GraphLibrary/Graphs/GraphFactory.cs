using System;
using System.Collections.Generic;
using System.Text;
using GraphLibrary.Graphs.GraphsFast;

namespace GraphLibrary.Graphs
{
    /// <summary>
    /// GraphFactory
    /// </summary>
    public class GraphFactory
    {
        public GraphFactory() { }

        public BaseGraph GetGraph(GraphTypes graphType)
        {
            switch (graphType)
            {
                case GraphTypes.GraphFastDirected:
                    return new GraphFastDirected();

                case GraphTypes.GraphFastUndirected:
                    return new GraphFastUndirected();

                case GraphTypes.GraphDirected:
                    throw new NotImplementedException();

                case GraphTypes.GraphUndirected:
                    throw new NotImplementedException();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
