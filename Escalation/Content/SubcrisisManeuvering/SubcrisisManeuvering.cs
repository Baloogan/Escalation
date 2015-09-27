using Escalation.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Escalation.Graph.GraphManager;

namespace Escalation.Content.Start
{
    public static class SubcrisisManeuvering
    {
        private const string Root = "/Content/SubcrisisManeuvering/";


        [Vertex("Index")]
        public static Vertex Index(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "SubcrisisManeuvering.html";
            Edge e;

            


            return v;
        }



        [Vertex("Rung1")]
        public static Vertex Rung1(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung1.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Rung2";

            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.PerceivedCommitment += 5;
            //e.State.PublicAwareness += 5;
            e.HTML = "Assert openly and explicitly that unless the dispute is resolved in the immediate future further escalation will occur.";
            v.Edges.Add(e);


            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.PublicAwareness += 20;
            e.HTML = "Officially inspire newspaper stories to the effect that the chief of state takes a serious view of the matter.";
            v.Edges.Add(e);




            return v;
        }


        [Vertex("Rung2")]
        public static Vertex Rung2(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung2.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Rung3";


            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.PerceivedCommitment += 10;
            //e.State.PublicAwareness += 5;
            //e.State.PerceivedInflexibility += 10;
            e.HTML = "Recall an ambassador for lengthy consultation.";
            v.Edges.Add(e);




            e = new Edge(d);
            //e.Disabled = e.State.PerceivedInflexibility < 5;
            e.State.VertexName = NextVertexName;
            //e.State.PerceivedCommitment += 5;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 10;
            e.HTML = "Refuse to facilitate negotiations on other issues.";
            v.Edges.Add(e);





            e = new Edge(d);
            //e.Disabled = e.State.Prestige < 5;
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.Prestige -= 5;
            e.HTML = "Make overtures to the other side's enemies";
            v.Edges.Add(e);






            e = new Edge(d);
            //e.Disabled = e.State.PerceivedInflexibility > 5;
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 5;
            e.HTML = "Denounce a treaty";
            v.Edges.Add(e);






            e = new Edge(d);
            //e.Disabled = e.State.Pressure > 15 && e.State.PoliticalCapital > 0;
            e.State.VertexName = NextVertexName;
            // e.State.Pressure += 5;
            //e.State.PoliticalCapital--;
            e.HTML = "Make a moderate but unmistakable legal or economic reprisal";
            v.Edges.Add(e);




            e = new Edge(d);
            //e.Disabled = e.State.PoliticalCapital > 0;
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PoliticalCapital--;
            e.HTML = "Replace an official in a key spot by one who is known to be 'hard' or 'tough'";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.HTML = "Start a violent publicity campaign, encourage mass meetings, 'spontaneous' public demonstrations";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a private threat through diplomatic channels";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a solemn and formal declaration";
            v.Edges.Add(e);

            return v;
        }

        [Vertex("Rung3")]
        public static Vertex Rung3(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung3.html";
            Edge e;

            string NextVertexName = "TraditionalCrises_Rung4";



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a solemn and formal declaration. Rock the boat.";
            v.Edges.Add(e);

            return v;
        }
    }
}