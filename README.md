[![NuGet](https://img.shields.io/badge/dynamic/xml?color=blue&label=NuGet&query=%2F&suffix=v%201.0.1&url=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FGraphNetworkLibrary%2F)](https://www.nuget.org/packages/GraphNetworkLibrary/)

# INA C# Network library

INA network library is a C# library for the creation, manipulation, and study of the structure, dynamics, and functions of complex networks. The inspiration for the library comes from the Networkx library for Python. The library includes most of the core algorithms for network analysis used during the INA course and some additional ones.

Authors: Jaka Jenko, Julijan Jug  

# How to use

[Documentation](https://jakajenko.github.io/INA_Graph_library/Documentation/index.html)


If you want to work big graphs inlcude

```
<runtime>
  <gcAllowVeryLargeObjects enabled="true" />
</runtime>
```

in your app.config file.


## Examples

```
//Reading grah from file
var graphFastDirected = new GraphFastDirected();
graphFastDirected.ReadPajek(@"..\graph.net");

//Printing graph nodes and edges
Console.WriteLine("Directed - nodes: " + graphFastDirected.NumberOfNodes);
Console.WriteLine("Directed - edges: " + graphFastDirected.NumberOfEdges);


//Generating graph
var graphGenerators = new GraphGenerators();
var graphFastUndirectedComplete = graphGenerators.CompleteGraph(100, GraphTypes.GraphFastUndirected);
```

# Performance comparison with NetworkX library

|                                                                             | C#                            | Python - networkx  |
| ----------------------------------------------------------------------------|:-----------------------------:|:------------------:|
| Loading pajek network (facebook.net)                                        | 0.991 sec <br> ~0.025GB RAM   | 41.839 sec <br> ~0.531GB RAM |
| Generating fully connected graph (5000 node)                                | 3.240 sec <br> ~0.674GB RAM   | 20.651 sec <br> ~3.5GB RAM |
| Generating erdos renyi graph (5000 nodes and 0,2% probability of edge)      | 5.127 sec <br> ~0.154GB RAM   | 6.066 sec <br> ~0.847GB RAM  |
| Generating erdos renyi graph (10000 nodes and 0,2% probability of edge)     | 22.171 sec <br> ~0.634GB RAM  | 26.372 sec <br> ~3.401GB RAM |
| Finding weakly connected components (graph with 4000 nodes)                 | 0.0005 sec    | 0.017 sec |


# Implementation plan    

- Graph 
  - fast directed/undirected - **DONE**  
  - normal directed/undirected  

- Import module
  - Pajek (with properties) - **DONE**
  - Edge list - **DONE**
  
- Bacis graph functions
  - List of nodes/edges - **DONE**
  - Number of nodes/eges - **DONE**
  - Add/Remove node/edge - **DONE**
  - Neighbors/degree (in, out, in+out) - **DONE**
  - Strongly/weakly connected components - **DONE**
  - Average degree - **DONE**
  - Power-law exponent

- Components finding
  - Conectivity (IsConnected, NumberOfConnectedComponents, NodeConnectedComonents) - **DONE**
  - Strong conectivity **DONE**
  - Weak conectivity - **DONE**

- Traversal algorithms
  - DFS (all neighbors, directed, reverse) - **DONE**
  - BFS (all neighbors, directed, reverse) - **DONE**

- Graph construction (for directed and undirected)
  - Erdoy Renyi - **DONE**
  - Fully connected - **DONE**
  - Preferential attachment - **DONE**

- Centrality
  - DegreeCentrality - **DONE**
  - Pagerank
  - BetweennesCentrality
  - Closeness centrality
  - ...
  
- Clustering
  - node clustering coefficient **DONE**
  - node harmonic mean distance
  - triangles **DONE**
  - transitivity **DONE**
  - average clustering **DONE**
  - generalized degree **DONE**

- Cycles 
  - All cycles
  - Minimum weigh cycle
  - Cycle basis **DONE**
   
- Paths
  - Shorthest path - **DONE**
    
- Liner algebra
  - Graph Laplacian (matrix)

- Community (Class ready but not yet implemented*)
  - modularity communities (algorithm)
  - girvan newman (Finds communities in a graph ) 

- Distance measures
  - Effective diameter **DONE**
  - Radius, Center, Periphery ***DONE***
 
 
