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
                current = 0,
                speed = 1
            },
            new Robot
            {
                id = 1,
                current = 1,
                speed = 2
            },
            new Robot
            {
                id = 2,
                current = 0,
                speed = 2
            }
        ]);

        static int robotCount = 3;

        static double minTime = double.MaxValue;

        static int[,] network = { };
        
        public static void Call()
        {
            network = MakeNetwork(1);

            Step();
        }

        static int[,] MakeNetwork(int count = 6)
        {
            
            int[][] list =
            [
                [0, 1, 1],
                //[0, 2, 1],
                //[1, 2, 1],
                //[1, 4, 1],
                //[2, 3, 1],
                //[3, 4, 1],
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
                network[list[i][0], list[i][1]] = list[i][2];
                network[list[i][1], list[i][0]] = list[i][2];
            }

            return network;
        }

        static void Step()
        {
            while (true)
            {

                if (didMeet(robotCount))
                {
                    break;
                }

                var node = queue.Dequeue();

                for (int i = 0; i < network.GetLength(0); i++)
                {
                    if (node.current >= network.GetLength(0))
                    {
                        Console.WriteLine("Роботы никогда не встретятся");
                        return;
                    }

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
                                new Robot
                                {
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

            if (minTime >= 0)
            {
                Console.WriteLine($"Время до встречи: {minTime.ToString("F")}");
                return;
            } 
            else
            {
                Console.WriteLine("Роботы никогда не встретятся");
            }
        }

        static bool didMeet(int count)
        {
            var zeroth = queue.Where(robot => robot.id == 0);
            var first = queue.Where(robot => robot.id == 1);
            var second = queue.Where(robot => robot.id == 2);
            //Console.WriteLine($"{zeroth.Count()} {first.Count()} {second.Count()}");
            
            bool isThreeRobots = count == 3;

            foreach (Robot robot0 in zeroth) 
            {
                foreach (Robot robot1 in first)
                {
                    if (isThreeRobots)
                    {
                        foreach (Robot robot2 in second)
                        {
                            bool canMeet = robot0.time == robot1.time && robot0.time == robot2.time;
                            bool didMeetAtCity = robot0.current == robot1.current && robot0.current == robot2.current && robot0.distance == 0 && robot1.distance == 0 && robot2.distance == 0;
                            bool canMeetEnRoute = 
                                robot0.current == robot1.next && 
                                robot0.next == robot1.current && 
                                (robot0.current == robot2.current && robot0.next == robot2.next|| robot0.current == robot1.current && robot0.next == robot1.next);

                            if (canMeet)
                            {
                                
                                if (canMeetEnRoute && (
                                    robot0.speed != robot1.speed || 
                                    robot0.speed != robot2.speed || 
                                    robot1.speed != robot2.speed
                                    ))
                                {
                                    var counter = 0;
                                    for (int i = 0; i < network.GetLength(0); i++)
                                    {
                                        if (network[robot0.current, i] != 0)
                                        {
                                            counter++;
                                        }
                                        if (network[robot0.next, i] != 0)
                                        {
                                            counter++;
                                        }
                                        
                                    }
                                    if (counter == 2)
                                    {
                                        minTime = -1;

                                        return true;
                                    }
                                }

                                if (didMeetAtCity)
                                {
                                    var time = robot0.time - 0.5;
                                    minTime = time;
                                    return true;
                                }

                                if (canMeetEnRoute)
                                {
                                    var time = (double)network[robot0.current, robot0.next] / (robot0.speed + robot1.speed);
                                    minTime = time;
                                    return true;
                                }
                            }
                        }
                    }
                    else
                    {
                        bool canMeet = robot0.time == robot1.time;
                        bool didMeetAtCity = robot0.current == robot1.current && robot0.distance == 0 && robot1.distance == 0;
                        bool didMeetEnRoute = robot0.next == robot1.current && robot0.current == robot1.next;

                        if (canMeet && (didMeetAtCity || didMeetEnRoute) )
                        {
                            if (didMeetAtCity)
                            {
                                var time = robot0.time;
                                minTime = time;
                                return true;
                            } 
                            else
                            {
                                var time = (double)network[robot0.current, robot0.next] / (robot0.speed + robot1.speed);
                                minTime = time;
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}
