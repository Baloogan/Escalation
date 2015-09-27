﻿using Escalation.Graph;
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
            e.State.VertexName = "SubcrisisManeuvering_Rung1";
            e.State.Rank1.Played++;
            //e.State.Leadership += 10;
            e.HTML = "Assume political control over crisis. Communicate with allies, establish a firm leadership position in NATO and with non-NATO allies. Establish continuous high level lines of communication.";
            v.Edges.Add(e);

            e = new Edge(d);
            e.State.VertexName = "SubcrisisManeuvering_Rung1";
            //e.State.Leadership -= 10;
            //e.State.Prestige -= 10;
            e.Disabled = true;
            e.DisabledReason = "lol";
            e.HTML = "Attempt to deflect political control.";
            v.Edges.Add(e);

            return v;
        }
    }
}