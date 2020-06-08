# INA C# Graph library

INA graph library is a C# library for the creation, manipulation, and study of the structure, dynamics, and functions of complex networks. The inspiration for the library comes from the Networkx library for Python. The library includes most of the core algorithms for network analysis used during the INA course and some additional ones.

Authors: Jaka Jenko, Julijan Jug, Blaž Kugonič  

# How to use
If you want to work big graphs inlcude

```
<runtime>
  <gcAllowVeryLargeObjects enabled="true" />
</runtime>
```

in your app.config file.

# Results

|                                                                             | C# \| RAM           | Python - networkx  |
| ----------------------------------------------------------------------------|:-------------:| ----------:|
| Loading pajek network (facebook.net)                                        | 0.991 sec     | 41.839 sec |
| Generating fully connected graph (5000 node)                                | 18.226 sec    | 25.248 sec  |
| Generating erdos renyi graph (5000 nodes and 0,2% probability of edge)      | 5.127 sec     | 7.441 sec  |
| Generating erdos renyi graph (10000 nodes and 0,2% probability of edge)     | 25.271 sec    | 29.872 sec |
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
  - Network distances - effective diameter (90% of network distances is network diameter)
  - Power-law exponent

- Components finding
  - Conectivity (IsConnected, NumberOfConnectedComponents, NodeConnectedComonents) - **DONE**
  - Strong conectivity - **DONE**
  - Weak conectivity

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
  - node clustering coefficient
  - node harmonic mean distance
  
- Cycles 
  - All cycles
  - Minimum weigh cycle
   
- Paths
  - Shorthest path - **DONE**
    
- Liner algebra
  - Graph Laplacian (matrix)

- Community (Class ready but not yet implemented*)
  - modularity communities (algorithm)
  - LFR benchmark graph
  - girvan newman (Finds communities in a graph ) 

 
 
