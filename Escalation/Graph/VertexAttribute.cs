using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Graph
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VertexAttribute : Attribute
    {
        public VertexAttribute(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
    }
}