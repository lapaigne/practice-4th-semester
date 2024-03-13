using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_4th_semester
{
    internal class Labyrinth
    {
        enum State
        {
            Empty,
            Wall,
            Visited
        }

        static string[] labyrinth = new string[]
        {
            " X   X    ",
            " X XXXXX X",
            "       X  ",
            " XXXXXXX X",
            "         X",
            " XXX XXXXX",
            " X        ",
        };
     
        // сводится к тому, что мы помечаем (x,y) как посещенную и затем пытаемся посмотреть все точки, в которые мы можем дойти из (x,y)
        // обход в глубину - выбираем одно направление, идем до конца, пока не исчерпаем это направление, возвращаемся к точке выбора и идем в другом направлении
        // т.о. гарантируем, что посетим все точки лабиринта до которых можно было дойти из начальной точки
        static void Visit(State[,] map, int x, int y)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1)) return;
            if (map[x, y] != State.Empty) return;
            map[x, y] = State.Visited;
            Print(map);

            for (var dy = -1; dy <= 1; dy++)
            {
                for (var dx = -1; dx <= 1; dx++)
                {
                    if (dx != 0 && dy != 0)
                    { 
                        continue;
                    }
                    else
                    {
                        Visit(map, x + dx, y + dy);
                    }
                }
            }
        }

        public static void Call()
        {
            var map = new State[labyrinth[0].Length, labyrinth.Length];
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = labyrinth[y][x] == ' ' ? State.Empty : State.Wall;
                }
            }

            Print(map);
            Visit(map, 0, 0);
        }

        static void Print(State[,] map)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            
            for (int x = 0; x < map.GetLength(0) + 2; x++)
            {
                Console.Write("X");
            }
            
            Console.WriteLine();
            
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.Write("X");
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    switch (map[x, y])
                    {
                        case State.Wall: Console.Write("X"); break;
                        case State.Empty: Console.Write(" "); break;
                        case State.Visited: Console.Write("."); break;
                    }
                }
                Console.WriteLine("X");
            }

            for (int x = 0; x < map.GetLength(0) + 2; x++)
            {
                Console.Write("X");
            }
            Console.ReadKey();
        }
    }
}
