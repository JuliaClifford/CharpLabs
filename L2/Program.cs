using System;

namespace L2
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;

            try
            {
                Console.Write("Введите стартовое значение для произведения ряда: ");
                input = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            int first = input * input;
            int finish = first * input;

            double result = 1; 

            if (0 <= first && first <= finish)
            {
                for (int k = first; k < finish; k++)
                {
                    result *= (3*k + Math.Pow((-1), Math.Pow(k, 2) - k + 1) * k) / (2 * Math.Pow(k, 2) + 1);
                }
                Console.WriteLine($"Результат исчесления произведения ряда с стартовым числом {input} = {result}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.ReadKey();
            }
        }
    }
    
}
