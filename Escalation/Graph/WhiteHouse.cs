using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Graph
{
    public class WhiteHouse
    {
        public static Vertex WelcomeMrPresident(GraphData d)
        {
            Vertex v = new Vertex();
            v.HTML = "Welcome Mr President!";
            v.Edges.Add(new Edge() { });
            return new Vertex();
        }
    }
}