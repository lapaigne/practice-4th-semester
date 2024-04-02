using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// метод расширений класса Node

namespace practice_4th_semester.Graphs
{
    static class NodeExtensions
    {
        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(startNode);

            var visited = new HashSet<Node>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (visited.Contains(node)) continue;

                visited.Add(node);
                yield return node;

                foreach (var nextNode in node.IncidentNodes)
                {
                    queue.Enqueue(nextNode);
                }
            }
        }

        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var stack = new Stack<Node>();
            stack.Push(startNode);

            var visited = new HashSet<Node>();
            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (visited.Contains(node)) continue;

                visited.Add(node);
                yield return node;

                foreach (var nextNode in node.IncidentNodes)
                {
                    stack.Push(nextNode);
                }
            }
        }

        public static IEnumerable<IEnumerable<Node>> FindConnectedComponents(this Graph graph)
        {
            var marked = new HashSet<Node>();

            while (true)
            {
                // сначала ищем вершину, которая не помечена
                // берем граф, берем все его вершины, выбираем те из них, которые не входят в список
                var node = graph.Nodes.Where(z=>!marked.Contains(z)).FirstOrDefault();

                //если таких вершин не нашлось
                if (node == null) break;

                // иначе запускаем поиск в ширину из этой вершины
                // нужно будет по нему пройтись 2 раза, складываем в лист
                var breadthSearch = node.BreadthSearch().ToList(); // список всех вершин, которые лежат в той же компоненте связности, что и node

                // вносим каждую из посещенных вершин в список
                foreach (var visitedNode in breadthSearch) // все эти вершины заносим в список отмеченных
                {
                    marked.Add(visitedNode);
                    yield return breadthSearch;
                }
                // получили здесь список вершин, которые достижимы из вершины node

            }
        }
    }
}

