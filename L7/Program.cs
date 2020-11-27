using  System;
using System.Collections.Generic;

namespace L7
{
    
    internal class Program
    {

        public static int CountPrimeNums(List<int> nums)
        {
            bool isPrime = false;
            int primeCounter = 0;
            foreach (var num in nums)
            {
                if (num > 1)
                {
                    for (int i = 2; i < num; i++)
                    {
                        if (num%i==0 && num != 2)
                        {
                            isPrime = false;
                            break;
                        }
                        isPrime = true;
                    }
                    

                }
                else
                {
                    isPrime = false;
                }

                if (isPrime)
                {
                    primeCounter += num;
                }
            }

            return primeCounter;
        }

        public static int CountEvenNums(List<int> nums)
        {
            int evenCounter = 0;

            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    evenCounter += num;
                }
            }
            return evenCounter;
        }
        
        private static void GenerateList(ref List<int> nums)
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++) nums.Add(rand.Next(10));
        }
        
        public static void Main(string[] args)
        {
            var nums = new List<int>();
            GenerateList(ref nums);
            
            
            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine($"Num #{i} is {nums[i]}");
            }

            Console.WriteLine($"Sum of all even nums is : {CountEvenNums(nums)}");
            Console.WriteLine($"Sum of all prime nums is : {CountPrimeNums(nums)}");
        }
    }
}