using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            string[] lines = System.IO.File.ReadAllLines(@"D:\Projects\Graph\Graph\graph.txt");
            string[] qtdVertex_Type = lines[0].Split(',');
            int qtdVertex = Int32.Parse(qtdVertex_Type[0]);
            string type = qtdVertex_Type[1];

            for (int i = 1; i <= qtdVertex; i++)
            {
                graph.Vertex.Add(new Vertex(i.ToString(), i.ToString()));
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                graph.Edges.Add(new Edge(data[0], data[1], ""));

                if(type.Equals("ND"))
                    graph.Edges.Add(new Edge(data[1], data[0], ""));
            }

            //Console.WriteLine(graph.Adjacent("1", "2"));
            //Console.WriteLine(graph.Adjacent("7", "5"));
            //Console.WriteLine(graph.Adjacent("5", "2"));
            //Console.WriteLine(graph.Degree("14"));
            //Console.ReadKey();

            Serializer.Serialize(graph, "D:\\Projects\\Graph\\Graph\\graphPlot.dgml");
        }
    }
}
