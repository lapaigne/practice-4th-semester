namespace practice_4th_semester
{
    internal class Reversed
    {
        public static void WriteReversed(char[] items, int startIndex)
        {
            if (startIndex == items.Length - 1) return;
            WriteReversed(items, startIndex + 1);
            Console.Write(items[startIndex]);
        }
    }
}
