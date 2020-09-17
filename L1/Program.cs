using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randV = new Random();
            byte v1 = (byte)randV.Next(1, 10);
            byte v2 = (byte)randV.Next(1, 10);
            float temp1 = randV.Next(0, 100) + 0.33f;
            float temp2 = randV.Next(0, 100);

            float result = (v1 * temp1 + v2 * temp2) / (v1 + v2);

            Console.WriteLine($"Жидкость 1: Объём - {v1}, Температура - {temp1}");
            Console.WriteLine($"Жидкость 2: Объём - {v2}, Температура - {temp2}");
            Console.WriteLine($"Температура раствора при смешании - {Math.Round(result, 2)} градусов");

            Console.ReadKey();
        }
    }
}
