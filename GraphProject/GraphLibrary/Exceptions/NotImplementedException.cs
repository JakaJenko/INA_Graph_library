using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary.Exceptions
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string msg) : base(String.Format("NotImplemented: {}", msg)) { }
    }
}
