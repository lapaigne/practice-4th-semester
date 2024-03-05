using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester
{
    internal class Chess
    {
        public static void PlaceQueen(int[,] board, int queensLeft, int column, List<int[,]> list)
        {
            if (queensLeft == 0)
            {
                return;
            }

            if (column == board.GetLength(0))
            {
                if (IsValid(board))
                {
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            Console.Write(board[i,j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                return;
            }

            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                board[column, i] = 1;
                PlaceQueen(board, queensLeft - 1, column + 1, list);
                board[column, i] = 0;
            }
        }

        static bool IsValid(int[,] board)
        {
            var sumH = 0;
            var sumV = 0;
            var sumR = 0;
            var sumL = 0;
            for (int i = 0; i< board.GetLength(0); i++)
            {
                // todo
                
            }

            return false;
        }
    }
}
