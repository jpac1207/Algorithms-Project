using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graph
{
    public class Vertex
    {
        public Vertex()
        {

        }

        public Vertex(string id, string label)
        {
            this.Id = id;
            this.Label = label;
        }

        [XmlAttribute]
        public string Id;
        [XmlAttribute]
        public string Label;
    }
}
