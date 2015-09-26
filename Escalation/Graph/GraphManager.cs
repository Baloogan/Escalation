using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Graph
{
    public static class GraphManager
    {
        private static Dictionary<string, Func<GraphData, Vertex>> Vertexes;
        private static Dictionary<string, Func<GraphData, Edge>> Edges;
        public static Vertex VertexesVertex(string s, GraphData data)
        {
            init();
            return Vertexes[s](data);
        }
        public static Edge Edge(string s, GraphData data)
        {
            init();
            return Edges[s](data);
        }
        private static void init()
        {
            if (Vertexes != null && Edges != null)
                return;
            Vertexes = new Dictionary<string, Func<GraphData, Graph.Vertex>>();
            Edges = new Dictionary<string, Func<GraphData, Graph.Edge>>();


        }

    }
}