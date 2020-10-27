using System;

namespace L4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[10] { -1, 2, -5, 6, -7, 8, -9, 12, -13, 2 };
            bool isAllPaired = false;
            bool isPrime = false;
            int whoBrokeAll = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if ((arr[i] % 2) != ((arr[i + 1]) % 2))
                {
                    isAllPaired = true;
                    continue;
                }
                else
                {
                    isAllPaired = false;
                    whoBrokeAll = arr[i + 1];
                    break;
                }
            }
            if (isAllPaired)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(whoBrokeAll);
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {

                if ((arr[i] < 0) == ((arr[i + 1]) > 0) || (arr[i] > 0) == ((arr[i + 1]) < 2))
                {
                    isPrime = true;
                    continue;
                }
                else
                {
                    isPrime = false;
                    whoBrokeAll = arr[i + 1];
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(whoBrokeAll);
            }
            Console.ReadKey();
        }
    }
}