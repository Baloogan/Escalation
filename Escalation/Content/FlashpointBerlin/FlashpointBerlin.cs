using Escalation.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Escalation.Graph.GraphManager;

namespace Escalation.Content.Start
{
    public static class FlashpointBerlin
    {
        private const string Root = "/Content/FlashpointBerlin/";

        [Vertex("Intro")]
        public static Vertex Intro(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Intro.html";
            Edge e;



            e = new Edge(d);
            e.State.VertexName = "FlashpointBerlin_Subcrisis";
            e.State.Leadership += 10;
            e.HTML = "Assume political control over crisis. Communicate with allies, establish a firm leadership position in NATO and with non-NATO allies. Establish continuous high level lines of communication.";
            v.Edges.Add(e);

            e = new Edge(d);
            e.State.VertexName = "FlashpointBerlin_Subcrisis";
            e.State.Leadership -= 10;
            e.State.Prestige -= 10;
            e.Disabled = true;
            e.DisabledReason = "lol";
            e.HTML = "Attempt to deflect political control.";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Subcrisis")]
        public static Vertex Subcrisis(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Subcrisis.html";
            Edge e;

            string NextVertexName = "FlashpointBerlin_Subcrisis";

            e = new Edge(d);
            e.Disabled = e.State.PerceivedCommitment < 5;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 1);
            e.State.PerceivedCommitment += 5;
            e.HTML = "Assert openly and explicitly that unless the dispute is resolved in the immediate future further escalation will occur.";
            v.Edges.Add(e);


            e = new Edge(d);
            e.Disabled = e.State.PerceivedCommitment < 5;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 1);
            e.State.PerceivedCommitment += 5;
            e.State.PublicAwareness += 20;
            e.HTML = "Officially inspire newspaper stories to the effect that the chief of state takes a serious view of the matter.";
            v.Edges.Add(e);


            e = new Edge(d);
            e.Disabled = e.State.RelevantAmbassadorsAbroad > 0;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.PerceivedCommitment += 10;
            e.State.PublicAwareness += 5;
            e.State.PerceivedInflexibility += 10;
            e.State.RelevantAmbassadorsAbroad--;
            e.HTML = "Recall an ambassador for lengthy consultation.";
            v.Edges.Add(e);




            e = new Edge(d);
            e.Disabled = e.State.PerceivedInflexibility < 5;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.PerceivedCommitment += 5;
            e.State.Pressure += 5;
            e.State.PerceivedInflexibility += 10;
            e.HTML = "Refuse to facilitate negotiations on other issues.";
            v.Edges.Add(e);





            e = new Edge(d);
            e.Disabled = e.State.Prestige < 5;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.Pressure += 5;
            e.State.Prestige -= 5;
            e.HTML = "Make overtures to the other side's enemies";
            v.Edges.Add(e);






            e = new Edge(d);
            e.Disabled = e.State.PerceivedInflexibility > 5;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.Pressure += 5;
            e.State.PerceivedInflexibility += 5;
            e.HTML = "Denounce a treaty";
            v.Edges.Add(e);






            e = new Edge(d);
            e.Disabled = e.State.Pressure > 15 && e.State.PoliticalCapital > 0;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.Pressure += 5;
            e.State.PoliticalCapital--;
            e.HTML = "Make a moderate but unmistakable legal or economic reprisal";
            v.Edges.Add(e);




            e = new Edge(d);
            e.Disabled = e.State.PoliticalCapital > 0;
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.Pressure += 5;
            e.State.PoliticalCapital--;
            e.HTML = "Replace an official in a key spot by one who is known to be 'hard' or 'tough'";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.HTML = "Start a violent publicity campaign, encourage mass meetings, 'spontaneous' public demonstrations";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 2);
            e.State.Pressure += 5;
            e.State.PerceivedInflexibility += 5;
            e.HTML = "Make a private threat through diplomatic channels";
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = NextVertexName;
            e.State.Pressure += 5;
            e.State.PerceivedInflexibility += 5;
            e.State.HighestRung = Math.Max(e.State.HighestRung, 3);
            e.HTML = "Make a solemn and formal declaration";
            v.Edges.Add(e);













            return v;
        }
    }
}