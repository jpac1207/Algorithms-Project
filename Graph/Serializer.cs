using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Graph
{
    public class Serializer
    {
        public struct Node
        {
            [XmlAttribute]
            public string Id;
            [XmlAttribute]
            public string Label;

            public Node(string id, string label)
            {
                this.Id = id;
                this.Label = label;
            }
        }

        public struct Link
        {
            [XmlAttribute]
            public string Source;
            [XmlAttribute]
            public string Target;
            [XmlAttribute]
            public string Label;
            [XmlAttribute]
            public string StrokeThickness;

            public Link(string source, string target, string label, string strokeThickness)
            {
                this.Source = source;
                this.Target = target;
                this.Label = label;
                this.StrokeThickness = strokeThickness;
            }
        }


        public struct SerializableGraph
        {
            public Node[] Nodes;
            public Link[] Links;
        }

        public static void Serialize(Graph graph, string xmlpath)
        {
            SerializableGraph lvgraph = new SerializableGraph();
            List<Node> nodes = new List<Node>();
            List<Link> links = new List<Link>();

            foreach (var node in graph.Vertex)
            {
                Node lvnode = new Node();
                lvnode.Id = node.Id;
                lvnode.Label = node.Label;
                nodes.Add(lvnode);
            }

            lvgraph.Nodes = nodes.ToArray();

            foreach (var vertex in graph.Edges)
            {
                Link lvlink = new Link();
                lvlink.Source = vertex.Origin;
                lvlink.Target = vertex.Destiny;
                lvlink.Label = vertex.Label;
                lvlink.StrokeThickness = "0,0,0";
                links.Add(lvlink);
            }

            lvgraph.Links = links.ToArray();

            XmlRootAttribute root = new XmlRootAttribute("DirectedGraph");
            root.Namespace = "http://schemas.microsoft.com/vs/2009/dgml";
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableGraph), root);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(xmlpath, settings);
            serializer.Serialize(xmlWriter, lvgraph);
        }
    }
}
