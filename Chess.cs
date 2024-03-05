using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester
{
    internal class Chess
    {
        public static void Call()
        {
            var board = MakeEmptyBoard(4);
            var list = new List<int[]>();
            PlaceQueen(board, 4, 0, list);
            foreach (var item in list)
            {
                //Print(item);
                //Console.WriteLine();
            }
            Console.WriteLine(list.Count);
        }

        public static void PlaceQueen(int[] board, int queensLeft, int column, List<int[]> list)
        {
            if (!IsValid(board))
            {
                return;
            }

            Console.WriteLine(string.Join(' ', board));
            Console.WriteLine(IsValid(board));
            Print(board);

            if (queensLeft == 0)
            {
                return;
            }

            if (column == board.Length)
            {
                if (queensLeft > 0)
                {
                    return; 
                }

                if (IsValid(board))
                {
                    list.Add(board);
                }
                return;
            }

            for (int i = board.Length - 1; i >= 0; i--)
            {
                board[column] = i;
                PlaceQueen(board, queensLeft - 1, column + 1, list);
            }
        }

        public static bool IsValid(int[] board)
        {
            for (int i = 1; i < board.Length + 1; i++) // step
            {
                for (int j = 0; j < board.Length; j++) // position
                {
                    if (j + i < board.Length)
                    {
                        //Console.WriteLine(board[j] + " " + board[j + i] + " " + j + " " + (j + i));
                        if (board[j] == -1 || board[j + i] == -1)
                        {
                            continue;
                        }
                        if (Math.Abs(board[j] - board[j + i]) == i || board[j] - board[j + i] == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return true;
        }

        public static int[] MakeEmptyBoard(int size)
        {
            var array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }

            return array;
        }

        public static void Print(int[] board)
        {
            var array = new string[board.Length];
            for (int i = 0; i < board.Length; i++)
            {
                array[i] = new string('0', board.Length);
            }

            for (int i = 0; i < board.Length; i++)
            {
                StringBuilder builder = new StringBuilder(array[i]);
                if (board[i] > -1)
                {
                    builder[i] = '1';
                    array[board[i]] = builder.ToString();
                } 
            }

            foreach (var s in array)
            {
                Console.WriteLine(s);
            }

        }
    }
}
