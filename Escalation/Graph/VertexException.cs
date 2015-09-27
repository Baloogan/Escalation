using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Graph
{
    public class VertexException : Exception
    {
        public VertexException(string Message) : base(Message)
        {
        }
    }
}