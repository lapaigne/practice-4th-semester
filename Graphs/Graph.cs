using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester.Graphs
{
    internal class Graph
    {
        private Node[] nodes;

        public Graph(int nodesCount)
        {
            nodes = Enumerable.Range(0, nodesCount).Select(z => new Node(z)).ToArray();
        }

        public int Length { get { return nodes.Length; } }

        public Node this[int index] { get { return nodes[index]; } }

        public IEnumerable<Node> Nodes
        {
            get
            {
                foreach (var node in nodes) yield return node;
            }
        }

        public void Connect(int index1, int index2)
        {
            Node.Connect(nodes[index1], nodes[index2], this);
        }

        public void Delete(Edge edge)
        {
            Node.Disconnect(edge);
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return nodes.SelectMany(z => z.IncidentEdges).Distinct();
            }
        }

        public static Graph MakeGraph(params int[] incidentNodes)
        {
            var graph = new Graph(incidentNodes.Max() + 1);
            for (int i = 0; i < incidentNodes.Length - 1; i += 2)
                graph.Connect(incidentNodes[i], incidentNodes[i + 1]);
            return graph;
        }

        public static List<Node> BreadthSearch(Node startNode)
        {
            var result = new List<Node>();
            var queue = new Queue<Node>();

            queue.Enqueue(startNode);

            // нужен список тех вершин, в которых мы уже находились, используем hashSet
            var visited = new HashSet<Node>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                // если уже были в этой вершине, то ее не нужно рассматривать снова
                if (visited.Contains(node)) continue;

                // иначе ее нужно добавить в список просмотренных
                visited.Add(node);

                // чтобы сфоримровать результат также добавим это в result
                result.Add(node);

                // используем 2 структуры данных, потому что помним, что поиск в result, т.е. в списке имеет сложность порядка длины этого массива

                // все вершины, которые инцидентны данной, нужно внести в очередь
                foreach (var nextNode in node.IncidentNodes)
                {
                    queue.Enqueue(nextNode);
                }
            }

            return result;
        }
    }
}
