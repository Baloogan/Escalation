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
        private const string Root = "/Content/FlashpointBerlin/";

        [Vertex("Intro")]
        public static Vertex Intro(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Intro.html";
            Edge e;

            e = new Edge(d);
            e.State.VertexName = "FlashpointBerlin_PoliticalGesture";
            e.HTML = "Defuse situation with ";
            v.Edges.Add(e);

            return v;
        }
    }
}