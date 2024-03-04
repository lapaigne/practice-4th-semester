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

            Permutations.TestOnSize(1);
            Permutations.TestOnSize(2);
            Permutations.TestOnSize(0);
            Permutations.TestOnSize(3);
            Permutations.TestOnSize(4);

            // ---
            // combinations

            //Combinations.MakeCombinations(new bool[5], 3, 0);
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
