using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Graph
{
    public class Edge
    {
        public Edge()
        {

        }

        public Edge(string origin, string destiny, string label)
        {
            this.Origin = origin;
            this.Destiny = destiny;
            this.Label = label;
        }

        [XmlAttribute]
        public string Origin;
        [XmlAttribute]
        public string Destiny;
        [XmlAttribute]
        public string Label;
    }
}
