namespace practice_4th_semester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // roman

            CallRoman();

            // ---
            // reversed

            //CallReversed();

            // ---
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
