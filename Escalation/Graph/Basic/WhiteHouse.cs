using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Escalation.Graph.GraphManager;

namespace Escalation.Graph
{
    public class WhiteHouse
    {
        [Vertex("WelcomeMrPresident")]
        public static Vertex WelcomeMrPresident(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = "/Content/WelcomeMrPresident.html";

            Edge e = new Edge(d);
            e.State.VertexName = "Step1";
            e.HTML = "Step one!";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Step1")]
        public static Vertex Step1(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = "/Content/Step1.html";

            Edge e = new Edge(d);
            e.State.VertexName = "WelcomeMrPresident";
            e.HTML = "Back to welcome";
            v.Edges.Add(e);

            e = new Edge(d);
            e.State.VertexName = "Step2";
            e.HTML = "Step 2";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Step2")]
        public static Vertex Step2(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = "/Content/Step2.html";

            Edge e = new Edge(d);
            e.State.VertexName = "Step1";
            e.HTML = "Back to step1";
            v.Edges.Add(e);

            return v;
        }
    }
}