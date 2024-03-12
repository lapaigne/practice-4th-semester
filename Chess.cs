using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester
{
    internal class Chess
    {
        public static void Call(int size)
        {
            var board = new int[size, size];
            var list = new List<int[,]>();
            PlaceQueen(board, size, 0, list);
            foreach (var item in list)
            {
                Print(item);
            }
            Console.WriteLine($"\n{list.Count}");
        }

        public static void PlaceQueen(int[,] board, int queensLeft, int column, List<int[,]> list)
        {
            if (!IsValid(board))
            {
                return;
            }

            if (column == board.GetLength(0) || queensLeft < 0)
            {
                list.Add((int[,])board.Clone());
                return;
            }

            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                board[i, column] = 1;
                PlaceQueen(board, queensLeft - 1, column + 1, list);
                board[i, column] = 0;   
            }
        }

        public static bool IsValid(int[,] board)
        {
            var size = board.GetLength(0);

            if (size <= 1)
            {
                return true;
            }

            // rows et cols

            for (int i = 0; i < size; i++)
            {
                var sumH = 0;
                var sumV = 0;

                for (int j = 0; j < size; j++)
                {
                    sumH += board[i, j];
                    sumV += board[j, i];
                }

                if (sumH > 1 || sumV > 1)
                {
                    return false;
                }
            }

            // diagonals

            for (int i = 1; i < 2 * (size - 1); i++)
            {
                var sumL = 0;
                var sumR = 0;

                for (int j = 0; j < size; j++)
                {
                    if (i - j >= 0 && i - j < size)
                    {
                        sumL += board[j, i - j];
                        sumR += board[i - j, size - 1 - j];
                    }
                }

                if (sumL > 1 || sumR > 1)
                {
                    return false;
                } 
            }
            return true;
        }

        public static void Print(int[,] board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write($"{board[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
