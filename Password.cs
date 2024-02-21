namespace practice_4th_semester
{
    internal class Password
    {
        public static void Call()
        {
            WriteAllWordsOfSize(1);
            WriteAllWordsOfSize(2);
            WriteAllWordsOfSize(0);
            WriteAllWordsOfSize(4);
        }
        static void WriteAllWordsOfSize(int size)
        {
            MakeSubsets(new char[size]);
        }
        static void MakeSubsets(char[] subset, int position = 0)
        {
            if (position >= subset.Length)
            {
                Console.WriteLine(new string(subset));
                return;
            }
            subset[position] = 'a';
            MakeSubsets(subset, position + 1);
            subset[position] = 'b';
            MakeSubsets(subset, position + 1);
            subset[position] = 'c';
            MakeSubsets(subset, position + 1);
        }
    }
}
