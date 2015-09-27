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

        [Vertex("Initial")]
        public static Vertex Initial(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Initial.html";

            Edge e = new Edge(d);
            e = new Edge(d);
            e.State.VertexName = "Start_Settings";
            e.HTML = "Okay!";
            v.Edges.Add(e);

            return v;
        }
        [Vertex("Settings")]
        public static Vertex Settings(GraphData d)
        {
            Vertex v = new Vertex();
            v.Include = Root + "Settings.html";

            Edge e;


            e = new Edge(d);
            e.State.VertexName = "Start_Settings";
            if (!e.State.ShowDebug)
            {
                e.State.ShowDebug = true;
                e.HTML = "Turn Debug Mode on.";
            }
            else
            {
                e.State.ShowDebug = false;
                e.HTML = "Turn Debug Mode off.";
            }
            v.Edges.Add(e);


            e = new Edge(d);
            e.State.VertexName = "Start_Settings";
            if (!e.State.ShowDelta)
            {
                e.State.ShowDelta = true;
                e.HTML = "Show Deltas Mode on.";
            }
            else
            {
                e.State.ShowDelta = false;
                e.HTML = "Show Deltas Mode off.";
            }
            v.Edges.Add(e);



            e = new Edge(d);
            e.State.VertexName = "Start_Scenarios";
            e.HTML = "Okay. I'm done changing settings.";
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
            e.State.DateTime = new DateTime(1965, 5, 1);
            e.State.EnemyLeader = "Leonid Brezhnev";
            
            e.HTML = "Flashpoint Berlin, 1965";

            v.Edges.Add(e);

            return v;
        }
    }
}