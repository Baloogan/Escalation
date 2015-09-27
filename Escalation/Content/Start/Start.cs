using Escalation.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Escalation.Graph.GraphManager;

namespace Escalation.Content.Start
{
    public static class Start
    {
        private const string Root = "/Content/Start/";

        [Vertex("Step1")]
        public static Vertex Step1(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Step1.html";

            Edge e = new Edge(d);
            e = new Edge(d);
            e.State.VertexName = "Start_Step2";
            e.HTML = "Okay!";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Step2")]
        public static Vertex Step2(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Step2.html";

            Edge e = new Edge(d);
            e.State.VertexName = "Start_Scenarios";
            e.HTML = "Okay.";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Scenarios")]
        public static Vertex Scenarios(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Scenarios.html";

            Edge e = new Edge(d);
            e.State.VertexName = "FlashpointBerlin_Intro";
            e.State.Title = "Flashpoint Berlin, 1965";
            e.State.Nation = "the United States of America";
            e.State.EnemyNation = "the Soviet Union";
            e.State.EnemyLeader = "Leonid Brezhnev";
            e.HTML = "Flashpoint Berlin, 1965";

            v.Edges.Add(e);

            return v;
        }
    }
}