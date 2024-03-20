using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    internal class Program
    {
        const int n = 5;
        static int[,] garden = new int[n, n]
        {
        { 1, 2, 0, 5, 5 },
        { 0, 1, 2, 0, 1 },
        { 2, 6, 10, 2, 3 },
        { 4, 8, 3, 0, 1 },
        { 2, 3, 0, 0, 5 }
        };
        

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();
            Console.WriteLine("Результат работы садовников:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{garden[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static void Gardner1()
        {
            for (int i = 0; i < n; i++)
            {

                    for (int j = 0; j < n; j++)
                    {
                        if (garden[i, j] > 0)
                        {
                            int delay = garden[i, j];
                            garden[i, j] = -1;
                            Console.WriteLine($"Садовник 1 обработал участок [{i},{j}]");
                            Thread.Sleep(delay);
                        }
                    }
                
            }
        }
        static void Gardner2()
        {
            for (int i = n - 1; i >= 0; i--)
            {

                    for (int j = n - 1; j >= 0; j--)
                    {
                        if (garden[i, j] > 0)
                        {
                            int delay = garden[i, j];
                            garden[i, j] = -2;
                            Console.WriteLine($"Садовник 2 обработал участок [{i},{j}]");
                            Thread.Sleep(delay);
                        }
                    }
                
            }
        }
    }
}
