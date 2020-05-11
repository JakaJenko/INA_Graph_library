# INA C# Graph library

INA graph library is a C# library for the creation, manipulation, and study of the structure, dynamics, and functions of complex networks. The inspiration for the library comes from the Networkx library for Python. The library includes most of the core algorithms for network analysis used during the INA course and some additional ones.

Authors: Jaka Jenko, Julijan Jug, Blaž Kugonič  

# How to use
If you want to work big graphs inlcude

'<runtime>
  <gcAllowVeryLargeObjects enabled="true" />
</runtime>'

in your app.config file.

# Implementation plan    

- Graph 
  - directed
  - undirected
  - multigraph
  - fast version

- Import module
  - Pajek (with properties)
  - Edge list
  
- Bacis graph functions
  - List of nodes/edges
  - Number of nodes/eges
  - Add/Remove node/edge
  - Neighbors/degree (in, out, in+out)
  - Strongly/weakly connected components
  - Average degree
  - Network distances - effective diameter (90% of network distances is network diameter)
  - Power-law exponent

- Components finding
  - Largest connected component

- Traversal algorithms
  - DFS (all neighbors, directed, reverse)
  - BFS (all neighbors, directed, reverse)

- Graph construction (for directed and undirected)
  - Erdoy Renyi
  - Fully connected
  - Preferential attachment

- Centrality
  - DegreeCentrality
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
  - Shorthest path
    
- Liner algebra
  - Graph Laplacian (matrix)

- Community
  - modularity communities (algorithm)
  - LFR benchmark graph
  - girvan newman (Finds communities in a graph ) 

 
 
