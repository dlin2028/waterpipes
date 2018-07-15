using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidWaterPipes
{
    class Program
    {
        static void Main(string[] args)
        {
            // ■    
            while (true)
            {
                int iterations = 0;
                Console.WriteLine("enter size");
                int size = int.Parse(Console.ReadLine());

                int[] pipes = new int[size];
                Random rng = new Random();

                int highestPipe = 0;
                int highestPipeIndex = 0;
                int water = 0;

                for (int i = 0; i < size; i++)
                {
                    pipes[i] = rng.Next(2, 11);
                }

                ConsoleColor[,] grid = new ConsoleColor[size, 10];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        grid[i, j] = ConsoleColor.Black;
                    }
                }
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < pipes[i]; j++)
                    {
                        grid[i, j] = ConsoleColor.White;
                    }
                }

                int currentPipe = 0;
                while (currentPipe < size)
                {
                    bool edgeCase = true;
                    int index = currentPipe + 1;

                    highestPipe = 0;
                    while (index < size)
                    {
                        iterations++;
                        if ((pipes[index] < pipes[index - 1]) && edgeCase)
                        {
                            edgeCase = true;
                        }
                        else
                        {
                            edgeCase = false;
                        }
                        if (edgeCase && index == size - 1)
                        {
                            edgeCase = true;
                            break;
                        }

                        if (pipes[currentPipe] <= pipes[index])
                        {
                            highestPipeIndex = index;
                            highestPipe = pipes[index];
                            break;
                        }
                        if (highestPipe < pipes[index])
                        {
                            highestPipe = pipes[index];
                            highestPipeIndex = index;
                        }

                        index++;
                    }

                    if (edgeCase)
                    {
                        currentPipe++;
                        continue;
                    }


                    for (int i = currentPipe + 1; i < highestPipeIndex; i++)
                    {
                        iterations++;
                        if (highestPipe > pipes[currentPipe])
                        {
                            if (pipes[currentPipe] - pipes[i] > 0)
                            {
                                for (int j = pipes[i]; j < pipes[currentPipe]; j++)
                                {
                                    grid[i, j] = ConsoleColor.Red;
                                }
                                water += pipes[i] - pipes[currentPipe];
                            }
                        }
                        else
                        {
                            if (highestPipe - pipes[i] > 0)
                            {
                                for (int j = pipes[i]; j < highestPipe; j++)
                                {
                                    grid[i, j] = ConsoleColor.Red;
                                }
                                water += pipes[i] - highestPipe;
                            }
                        }
                    }
                    currentPipe++;
                }

                for (int j = 9; j >= 0; j--)
                {
                    for (int i = 0; i < size; i++)
                    {
                        Console.ForegroundColor = grid[i, j];
                        Console.Write("█");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("water:" + Math.Abs(water));
                Console.WriteLine("iterations: " + iterations);
            }
        }
    }
}

