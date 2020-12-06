using System;
using System.Collections.Generic;
using System.Linq;

namespace L5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = 4;
            int m = 5;
            Dictionary<int, int> counter = new Dictionary<int, int>();
            int [,] matrix = new int[4,5]
            {
                    {1, 2, 4, 1, 0},
                    {3, 3, 6, 9, 8},
                    {3, 4, 17, 9, 1},
                    {3, 9, 9, 9, 8}
            };
            var max = (from int x in matrix select x).Max();
            for (int i = 0; i < max + 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        if (matrix[j,k] == i)
                        {
                            if (counter.ContainsKey(i))
                            {
                                counter[i]++;
                            }
                            else
                            {
                                counter.Add(i, 1);
                            }
                        }
                    }
                }
            }
            List<int> values = new List<int>();
            for (int i = 0; i < max + 1; i++)
            {
                try
                {
                    Console.WriteLine($"{i} Встречается {counter[i]} раз");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{i} Встречается {0} раз");
                }
                
            }
            Console.ReadKey();
        }
    }
}