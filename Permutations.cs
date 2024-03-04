namespace practice_4th_semester
{
    internal class Permutations
    {
        static int[,] prices = { 
            { 0, 2, 4, 7 }, 
            { 2, 0, 3, 1 }, 
            { 4, 2, 0, 1 }, 
            { 3, 5, 2, 0 } 
        };

        public static void Evaluate(int[] permutations)
        {
            int price = 0;
            for (int i = 0; i < permutations.Length; i++)
            {
                price += prices[permutations[i], permutations[(i + 1) % permutations.Length]];
            }
            foreach (var e in permutations)
            {
                Console.Write($"{e} ");
            }
            Console.Write($"{price}");
            Console.WriteLine();
        }

        public static void MakePermutations(int[] permutation, int position)
        {
            if (position == permutation.Length)
            {
                Evaluate(permutation);
                return;
            }

            for (int i = 0; i < permutation.Length; i++)
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index != -1) continue;

                permutation[position] = i;
                MakePermutations(permutation, position + 1);
            }
        }

        static void WritePermutation(int[] permutation)
        {
            var strings = new List<string>();
            foreach (var i in permutation)
            {
                strings.Add(i.ToString());
            }
            Console.WriteLine(string.Join(" ", strings.ToArray()));
        }

        static void MakePermutations(int[] permutation, int position, List<int[]> result)
        {
            if (position == permutation.Length)
            {
                result.Add((int[])permutation.Clone());
                return;
            }
            else
            {
                for (int i = 0; i < permutation.Length; i++)
                {
                    var index = Array.IndexOf(permutation, i, 0, position);
                    if (index == -1)
                    {
                        permutation[position] = i;
                        MakePermutations(permutation, position + 1, result);
                    }
                }
            }
        }
    
        public static void TestOnSize(int size)
        {
            var result = new List<int[]>();
            MakePermutations(new int[size], 0, result);
            foreach (var permutation in result)
            {
                WritePermutation(permutation);
            }
        }
    }
}
