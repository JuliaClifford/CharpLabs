using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randV = new Random();
            int num = (int)randV.Next(-999, 999);
            int num1 = Math.Abs(num / 100);
            int num2 = Math.Abs(num / 10 % 10);
            int num3 = Math.Abs(num % 10);
            bool result = true;
            if(num1 != num2 && num1 != num3 && num1 != num3)
            {
                result = true;
                Console.WriteLine($"При генирировании получаем число: {num}");
                Console.WriteLine($"Выражение \"Все цифры даного числа разные\" {result}");
                Console.ReadKey();
            }
            else
            {
                result = false;
                Console.WriteLine($"Выражение \"Все цифры даного числа разные\" {result}");
                Console.ReadKey();
            }
        }
    }
}
