using Escalation.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Escalation.Graph.GraphManager;

namespace GraphOutput
{
    class Program
    {

        public static List<string> vertexes_visited = new List<string>();
        public static List<string> edges_visited = new List<string>();
        public static List<Tuple<string, string>> graph_links = new List<Tuple<string, string>>();
        public static List<Vertex> vertexes = new List<Vertex>();
        private static void Recurse(Vertex v)
        {
            if (vertexes_visited.Contains(v.Name))
                return;
            vertexes.Add(v);
            vertexes_visited.Add(v.Name);
            foreach (Edge e in v.Edges)
            {
                if (edges_visited.Contains(e.Name))
                    continue;
                edges_visited.Add(e.Name);
                //graph_links.Add(new Tuple<string, string>(v.Name, e.Name));
                //graph_links.Add(new Tuple<string, string>(e.Name, e.HTML));
                graph_links.Add(new Tuple<string, string>(v.Name, e.Name + " " + e.HTML));

                graph_links.Add(new Tuple<string, string>(e.Name + " " + e.HTML, e.State.VertexName));
                Vertex sub = GetVertex(new State() { VertexName = e.State.VertexName });
                Recurse(sub);
            }
        }



        static void Main(string[] args)
        {

            // Escalation.Graph.GraphManager.GraphData
            Vertex v = GetVertex(new State() { VertexName = "Start_Initial" });
            Recurse(v);
            string s = "";
            s += "digraph GRAPH_0 {";
            foreach (var g in graph_links)
            {
                s += $"\"{g.Item1}\"->\"{g.Item2}\"\n";
            }
            s += "}";
            System.IO.File.WriteAllText("b:\\file.dot", s);
            Process.Start(@"C:\Program Files (x86)\Graphviz2.38\bin\dot.exe", "b:\\file.dot -O -Tpng");
        }
    }
}
