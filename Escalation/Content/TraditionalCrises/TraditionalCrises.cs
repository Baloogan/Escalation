using Escalation.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Escalation.Graph.GraphManager;

namespace Escalation.Content.Start
{
    public static class TraditionalCrises
    {
        private const string Root = "/Content/TraditionalCrises/";
        
        [Vertex("Rung4")]
        public static Vertex Rung4(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung4.html";
            Edge e;

            string NextVertexName = "TraditionalCrises_Rung5";

            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.Stakes += 5;
            e.HTML = "A public and irrevocable increase in the stakes";
            v.Edges.Add(e);


            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.PublicAwareness += 20;
            e.HTML = "Officially inspire newspaper stories to the effect that the chief of state takes a serious view of the matter.";
            v.Edges.Add(e);

            


            return v;
        }


        [Vertex("Rung5")]
        public static Vertex Rung5(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung5.html";
            Edge e;

            string NextVertexName = "TraditionalCrises_Rung6";
            








            return v;
        }

        [Vertex("Rung6")]
        public static Vertex Rung3(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung3.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Rung3";

            

            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.Pressure += 5;
            e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a solemn and formal declaration";
            v.Edges.Add(e);













            return v;
        }
    }
}