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

            e = new Edge(d);
            e.Invisible = d.Start.Rank1.InHand <= 0;
            e.State.VertexName = "SubcrisisManeuvering_Rung1";
            e.State.Rank1.Played++;
            e.State.Rank1.InHand--;
            e.HTML = "Acknowledge Crisis";
            v.Edges.Add(e);




            e = new Edge(d);
            e.Invisible = d.Start.Rank2_poli.InHand <= 0;
            e.State.VertexName = "SubcrisisManeuvering_Rung2_poli";
            e.State.Rank2_poli.Played++;
            e.State.Rank2_poli.InHand--;
            e.HTML = "Make a Political Gesture";
            v.Edges.Add(e);




            e = new Edge(d);
            e.Invisible = d.Start.Rank2_econ.InHand <= 0;
            e.State.VertexName = "SubcrisisManeuvering_Rung2_econ";
            e.State.Rank2_econ.Played++;
            e.State.Rank2_econ.InHand--;
            e.HTML = "Make a Economic Gesture";
            v.Edges.Add(e);





            e = new Edge(d);
            e.Invisible = d.Start.Rank2_dipl.InHand <= 0;
            e.State.VertexName = "SubcrisisManeuvering_Rung2_dipl";
            e.State.Rank2_dipl.Played++;
            e.State.Rank2_dipl.InHand--;
            e.HTML = "Make a Diplomatic Gesture";
            v.Edges.Add(e);




            e = new Edge(d);
            e.Invisible = d.Start.Rank3.InHand <= 0;
            e.State.VertexName = "SubcrisisManeuvering_Rung3";
            e.State.Rank3.Played++;
            e.State.Rank3.InHand--;
            e.HTML = "Conclude subcrisis and address nation and world.";
            v.Edges.Add(e);

            return v;
        }



        [Vertex("Rung1")]
        public static Vertex Rung1(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung1.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Index";

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


        [Vertex("Rung2_poli")]
        public static Vertex Rung2_poli(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung2_poli.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Index";




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





            return v;
        }

        [Vertex("Rung2_econ")]
        public static Vertex Rung2_econ(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung2_econ.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Index";




            e = new Edge(d);
            //e.Disabled = e.State.Pressure > 15 && e.State.PoliticalCapital > 0;
            e.State.VertexName = NextVertexName;
            // e.State.Pressure += 5;
            //e.State.PoliticalCapital--;
            e.HTML = "Make a moderate but unmistakable legal or economic reprisal";
            v.Edges.Add(e);






            return v;
        }

        [Vertex("Rung2_dipl")]
        public static Vertex Rung2_dipl(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung2_dipl.html";
            Edge e;

            string NextVertexName = "SubcrisisManeuvering_Index";


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
            e.State.VertexName = NextVertexName;
            //e.State.Pressure += 5;
            //e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a private threat through diplomatic channels";
            v.Edges.Add(e);



            return v;
        }


        [Vertex("Rung3")]
        public static Vertex Rung3(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Rung3.html";
            Edge e;

            string NextVertexName = "TraditionalCrises_Index";



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