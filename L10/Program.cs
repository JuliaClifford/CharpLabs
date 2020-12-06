using System;

namespace L10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }

            foreach (var a in array)
            {
                Console.Write($"{a}, ");
            }
            array.ReplaceElems();
            Console.WriteLine();
            foreach (var a in array)
            {
                Console.Write($"{a}, ");
            }
        }
    }
}