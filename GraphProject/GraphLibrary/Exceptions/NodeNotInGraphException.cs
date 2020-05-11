using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Exceptions
{
    public class NodeNotInGraphException : Exception
    {
        public NodeNotInGraphException(int node) : base(String.Format("Node '{0}' doesn't exist in graph.", node)){ }
        public NodeNotInGraphException(string node) : base(String.Format("Node '{0}' doesn't exist in graph.", node)) { }
    }
}
