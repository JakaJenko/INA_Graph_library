using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphLibrary;
using GraphLibrary.Graphs;
using GraphLibrary.Graphs.GraphsFast;

namespace GraphProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var graphGenerators = new GraphGenerators();

            var graphFastDirected = new GraphFastDirected();
            var graphFastUndirected = new GraphFastUndirected();

            graphFastDirected.ReadPajek(@"H:\Jenko\Documents\Magisterij\1_letnik\ARPI_Analiza_Omrežij\INA_Graph_library\GraphProject\GraphProgram\Data\facebook.net");
            graphFastUndirected.ReadPajek(@"H:\Jenko\Documents\Magisterij\1_letnik\ARPI_Analiza_Omrežij\INA_Graph_library\GraphProject\GraphProgram\Data\facebook.net");

            Console.WriteLine("Directed - nodes: " + graphFastDirected.NumberOfNodes);
            Console.WriteLine("Directed - edges: " + graphFastDirected.NumberOfEdges);
            Console.WriteLine();
            Console.WriteLine("Unirected - nodes: " + graphFastUndirected.NumberOfNodes);
            Console.WriteLine("Unirected - edges: " + graphFastUndirected.NumberOfEdges);


            var graphFastDirectedComplete = graphGenerators.CompleteGraph(100);
            var graphFastUndirectedComplete = graphGenerators.CompleteGraph(100, GraphTypes.GraphFastUndirected);

            Console.WriteLine();
            Console.WriteLine("Directed complete - nodes: " + graphFastDirectedComplete.NumberOfNodes);
            Console.WriteLine("Directed complete - edges: " + graphFastDirectedComplete.NumberOfEdges);
            Console.WriteLine();
            Console.WriteLine("Unirected complete - nodes: " + graphFastUndirectedComplete.NumberOfNodes);
            Console.WriteLine("Unirected complete - edges: " + graphFastUndirectedComplete.NumberOfEdges);
        }
    }
}
