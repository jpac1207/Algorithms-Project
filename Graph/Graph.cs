using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Graph
{
    public class Graph
    {
        public Graph()
        {
            this.Vertex = new List<Vertex>();
            this.Edges = new List<Edge>();
        }

        public List<Vertex> Vertex;
        public List<Edge> Edges;

        public void AddNode(Vertex n)
        {
            this.Vertex.Add(n);
        }

        public void AddEdge(Edge l)
        {
            this.Edges.Add(l);
        }

        public bool Adjacent(string x, string y)
        {
            var allEdgesOfX = this.Edges.Where(e => e.Origin == x || e.Destiny == x).ToList();
            return allEdgesOfX.Where(e => e.Origin == y || e.Destiny == y).Count() > 0;
        }

        public int Degree(string x)
        {
            return this.Edges.Where(e => e.Origin == x || e.Destiny == x).Count();
        }

    }
}
