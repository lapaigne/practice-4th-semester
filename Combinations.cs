namespace practice_4th_semester
{
    internal class Combinations
    {
        public static void MakeCombinations(bool[] combination, int elementsLeft, int position)
        {
            if (elementsLeft == 0) {
                for (int i = position; i < combination.Length; i++)
                {
                    combination[i] = false;
                }

                foreach (var e in combination)
                {
                    Console.Write($"{(e ? 1 : 0)} ");
                }
                Console.WriteLine();
                return;
            }

            if (position == combination.Length)
            {
                return;
            }

            // в этом случае нужно разместить тоже самое кол-во элементов, начиная со следующей позиции
            combination[position] = false;    
            MakeCombinations(combination, elementsLeft, position + 1);

            // после этого говорим, что там будет лежать яблоко

            combination[position] = true;
            MakeCombinations(combination, elementsLeft - 1, position + 1);
        }
    }
}
