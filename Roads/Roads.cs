using System.Collections;
using System.Drawing;

namespace practice_4th_semester.Roads
{
    internal class Roads
    {
        static Queue<Robot> queue = new Queue<Robot>
        ([
            new Robot
            {
                id = 0,
                current = 1,
                speed = 1
            },
            new Robot
            {
                id = 1,
                current = 4,
                speed = 1
            },
            //new Robot
            //{
            //    id = 2,
            //    current = 0,
            //    speed = 2
            //}
        ]);

        static int[,] network = { };
        
        public static void Call()
        {
            network = MakeNetwork(6);

            for (int i = 0; i < 25; i++)
            {
                
                //Console.WriteLine($"{first.id} {first.current} >> {first.next} {first.time} {first.distance}");
                Step();
            }
        }

        static int[,] MakeNetwork(int count = 6)
        {
            
            int[][] list =
            [
                [0, 1],
                [0, 2],
                [1, 2],
                [1, 4],
                [2, 3],
                [3, 4],
            ];

            var max = -1;
            foreach (var pair in list)
            {
                if (pair[0] > max)
                {
                    max = pair[0];
                }

                if (pair[1] > max)
                {
                    max = pair[1];
                }
            }

            var network = new int[max + 1, max + 1];

            for (int i = 0; i < list.Length; i++)
            {
                network[list[i][0], list[i][1]] = 1;
                network[list[i][1], list[i][0]] = 1;
            }

            return network;
        }

        static void Step()
        {
            var node = queue.Dequeue();

            if (didMeet())
            {
                return;
            }

            for (int i = 0; i < network.GetLength(0); i++) 
            {
                if (network[node.current, i] > 0)
                {
                    if (node.next == -1) // если следующий город еще не выбран (только для начальных значений)
                    {
                        queue.Enqueue(
                            new Robot
                            {
                                id = node.id,
                                current = node.current,
                                time = node.time + .5,
                                distance = node.distance + .5 * node.speed,
                                next = i,
                                speed = node.speed
                            }
                        );
                    }
                    else if (node.distance == network[node.current, node.next]) // если достиг другого города, то выбирается новая точка
                    {
                        queue.Enqueue(
                            new Robot
                            {
                                id = node.id,
                                current = node.next,
                                time = node.time + .5,
                                distance = 0,
                                next = i,
                                speed = node.speed
                            }
                        );
                    }
                    else // если не достиг, то продолжает движение
                    {
                        queue.Enqueue( 
                            new Robot {
                                id = node.id,
                                current = node.current,
                                time = node.time + .5, 
                                distance = node.distance + .5 * node.speed,
                                next = node.next,
                                speed = node.speed
                            }
                        );
                    }
                }
            }
            
        }

        static bool didMeet()
        {

            foreach (Robot robot0 in queue) {
                foreach (Robot robot1 in queue)
                {
                    
                    bool canMeet = robot0.id != robot1.id && robot0.time == robot1.time;
                    bool didMeetAtCity = robot0.current == robot1.current;
                    bool didMeetEnRoute = robot0.next == robot1.current && robot0.current == robot1.next;

                    if (canMeet && (didMeetAtCity || didMeetEnRoute))
                    {
                        if (didMeetAtCity)
                        {
                            Console.WriteLine(robot0.time - 0.5);
                        }
                        else
                        {
                            var time = (double)network[robot0.current, robot0.next] / (robot0.speed + robot1.speed);
                            Console.WriteLine(time);
                        }
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
