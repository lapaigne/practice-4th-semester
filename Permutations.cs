using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practice_4th_semester
{
    internal class Permutations
    {
        public static void MakePermutations(int[] permutation, int position)
        {
            if (position == permutation.Length)
            {
                foreach (var e in permutation)
                {
                    Console.Write($"{e} ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < permutation.Length; i++)
            {
                bool found = false;
                for (int j = 0; j < position; j++)
                {
                    if (permutation[j] == i)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    continue;
                }
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
