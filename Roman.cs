using System.Text;

namespace practice_4th_semester
{
    internal class Roman
    {
        enum Numerals
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }
        static private string ModuloSwitcher(int number, int div, char lower, char mid, char upper)
        {
            switch (number / div)
            {
                case 1: return $"{lower}";
                case 2: return $"{lower}{lower}";
                case 3: return $"{lower}{lower}{lower}";
                case 4: return $"{lower}{mid}";
                case 5: return $"{mid}";
                case 6: return $"{mid}{lower}";
                case 7: return $"{mid}{lower}{lower}";
                case 8: return $"{mid}{lower}{lower}{lower}";
                case 9: return $"{lower}{upper}";
                default: return "";
            }
        }

        static public string ArabicToRoman(int input)
        {
            int number = input;
            var str = new StringBuilder();

            str.Append(ModuloSwitcher(number, 1000, 'M', ' ', ' '));
            number %= 1000;
            str.Append(ModuloSwitcher(number, 100, 'C', 'D', 'M'));
            number %= 100;
            str.Append(ModuloSwitcher(number, 10, 'X', 'L', 'C'));
            number %= 10;
            str.Append(ModuloSwitcher(number, 1, 'I', 'V', 'X'));

            return str.ToString();
        }

        static public int RomanToArabic(string input)
        {           
            int number = 0;
            var numerical = new LinkedList<int>(); 
            foreach (var ch in input)
            {
                numerical.AddLast((int)Enum.Parse<Numerals>(ch + ""));
            }

            for (var node = numerical.First; node != null; node = node.Next)
            {
                number += (node.Value < node.Next?.Value) ? -node.Value : node.Value;
            }

            return number;
        }        
    }
}
