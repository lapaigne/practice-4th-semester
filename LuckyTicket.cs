namespace practice_4th_semester
{
    internal class LuckyTicket
    {
        public static void FindAll()
        {
            var list = new List<int>();
            for (int i = 1; i < 1e6; i++) {
                var left = i / 1000;
                var right = i % 1000;

                if (left % 10 + left / 10 % 10 + left / 100 % 10 == right % 10 + right / 10 % 10 + right / 100 % 10)
                {
                    list.Add(i);
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{list[i]:D6}");
            }
            Console.WriteLine(list.Count);
        }

        public static void MakeCombinations(int[] combination, int elementsLeft, int position, List<string> list)
        {
            if (elementsLeft == 0)
            {
                if (combination[0] + combination[1] + combination[2] == combination[3] + combination[4]+ combination[5]) 
                {
                    list.Add(string.Join("", combination));       
                }
                return;
            }

            if (position == combination.Length)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                combination[position] = i;
                MakeCombinations(combination, elementsLeft - 1, position + 1, list);
            }
        }

        public static void Call()
        {
            var list = new List<string>();
            MakeCombinations(new int[6], 6, 0, list);

            for (int i = 1; i < 101; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine(list.Count - 1);
        }
    }
}
