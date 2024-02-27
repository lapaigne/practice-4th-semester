using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester
{
    internal class Test2702
    {
        public static int G(int x, int y)
        {
            if (y == 0) return x;
            
            return G(y, x % y);
        }

        public static int Calc(int n)
        {
            int res = 1;
            if (n > 1) res = 1 + Calc(n - 1);
            Console.WriteLine($"{res} \t {n}");

   
            return res;
        }

        public static int Calc2(int n)
        {
            int res = 1;
            if (n > 1)
            { 
                res = Calc2(n - 1) + Calc2(n - 2);
                Console.WriteLine($"{res} \t {n}");
            }


            return res;
        }

        public static int F0(int n)
        {
            int sum = 0;
            int step = 1;
            while (sum < n)
            {
                for (int j = 0; j < step; j++)
                    sum++;

                step *= 2;
            }
            return sum;
        }

        public static int F1(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j * j < n; j++)
                {
                    //Console.WriteLine($"{j * j}\t {n}");
                    sum++;
                }
            }
            return sum;
        }

        public static int F2(int n) 
        {
            int sum = 0;
            for (int j = 0; j * j < n; j++)
            {
                //Console.WriteLine($"{j * j}\t {n}");
                sum++;
            }

            return n * sum;

        }
    }
}
