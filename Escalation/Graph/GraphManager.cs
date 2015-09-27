using Escalation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Escalation.Graph
{
    public static class GraphManager
    {

        public class GraphData
        {
            public Game Game;
            public State Start;
        }

        public class Edge
        {
            public string HTML;
            public State State;
            public string Name;//provided in GraphManager
            public Edge(GraphData d)
            {
                State = GraphHelper.ShallowCopyEntity(d.Start);
            }
        }
        public class Vertex
        {
            public string Include;
            public string Name; //provided in GraphManager
            public List<Edge> Edges = new List<Edge>();

        }
        private static Dictionary<string, Func<GraphData, Vertex>> Vertexes = null;
        public static Vertex GetVertex(State s)
        {
            return GetVertex(s.VertexName, new GraphData() { Game = s.Game, Start = s });
        }
        private static Vertex GetVertex(string s, GraphData data)
        {
            init();
            Vertex v = Vertexes[s](data);
            v.Name = s;
            for (int i = 0; i < v.Edges.Count; ++i)
            {
                v.Edges[i].Name = $"{v.Name}.{i}";
            }
            return v;
        }
        public static void init()
        {
            if (Vertexes != null)
                return;
            Vertexes = new Dictionary<string, Func<GraphData, Vertex>>();

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods().Where(M => M.IsStatic))
                    {
                        var attribs = method.GetCustomAttributes(typeof(VertexAttribute), false);
                        if (attribs != null && attribs.Length > 0)
                        {
                            var va = attribs.OfType<VertexAttribute>().First();
                            string key = type.Name + "_" + va.Name;
                            if (Vertexes.ContainsKey(key))
                                throw new VertexException($"Vertex key collision {key}");
                            Vertexes[key] = (F) => (Vertex)method.Invoke(null, new object[] { F });
                        }
                    }
                }
            }
        }
    }
}