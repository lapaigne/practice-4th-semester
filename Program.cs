using practice_4th_semester.Graphs;

namespace practice_4th_semester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // roman

            //CallRoman();

            // ---
            // reversed

            //CallReversed();

            // ---
            // password

            //Password.Call();

            // ---
            // weights

            //Weights.Call();

            // ---
            //test2702

            //var num = Test2702.G(3, 21);

            //Console.WriteLine(Test2702.F1(11));
            //Console.WriteLine(Test2702.F1(16));

            //Console.WriteLine(Test2702.F2(11));
            //Console.WriteLine(Test2702.F2(16));

            //var num = Test2702.Calc2(3);

            //Console.WriteLine(num);

            // ---
            // permutations

            //Permutations.MakePermutations(new int[4], 0);

            //Permutations.TestOnSize(1);
            //Permutations.TestOnSize(2);
            //Permutations.TestOnSize(0);
            //Permutations.TestOnSize(3);
            //Permutations.TestOnSize(4);

            // ---
            // combinations

            //Combinations.MakeCombinations(new bool[5], 3, 0);

            // ---
            // tickets

            //LuckyTicket.FindAll();
            //LuckyTicket.Call();

            // ---
            // queens

            //Chess.Call(4);

            // ---
            // labyrinth

            //Labyrinth.Call();
            //Labyrinth.CallStack();
            //Labyrinth.CallQueue();

            // ---
            // roads

            Roads.Roads.Call();


        }

        static void CallGraph()
        {
            //var graph = new Graph(2);
            //graph[0].Connect(graph[1], graph);
            //var node = new Node(1);
            //graph[0].Connect(node, graph);
            // с одной стороны вершина (вновь созданная) не лежит в графе, в графе лежат другие созданные вершины, а с другой стороны к ней уже подсоединена нулевая вершина

            //graph.Connect(0, 1);

            // произведем поиск из нулевой вершины

            var graph = Graph.MakeGraph();

            foreach (var e in Graph.BreadthSearch(graph[0]))
            {
                Console.WriteLine(e);
            }

            //foreach (var e in DepthSearch(graph[0]))
            //{
            //    Console.WriteLine(e);
            //}
        }

        static void CallRoman()
        {
            var random = new Random();
            int number = random.Next(1, 4000);

            Console.WriteLine(number);

            var result = Roman.ArabicToRoman(number);

            Console.WriteLine(result);

            var output = Roman.RomanToArabic(result);

            Console.WriteLine(output);
        }

        static void CallReversed()
        {
            var items = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            Reversed.WriteReversed(items, 0);
        }
    }
}
