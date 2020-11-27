using System;

namespace L6
{
    internal class Program
    {
        public static int ReverseString(ref int nums)
        {
            var str = nums.ToString();
            var charArr = str.ToCharArray();
            Array.Reverse(charArr);
            str = new string(charArr);
            return Convert.ToInt32(str);
        }

        public static double ReverseString(ref double doStr)
        {
            var str = doStr.ToString();
            var separatedString = str.Split(',', '.');
            var charArr1 = separatedString[0].ToCharArray();
            var charArr2 = separatedString[1].ToCharArray();
            Array.Reverse(charArr1);
            Array.Reverse(charArr2);
            str = string.Join(",", new string(charArr1), new string(charArr2));
            return Convert.ToDouble(str);
        }

        public static string ReverseString(ref string str)
        {
            var charArr = str.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        public static string ReverseString(ref string doubleStr, char separator)
        {
            var separatedString = doubleStr.Split(separator);
            var charArr1 = separatedString[0].ToCharArray();
            var charArr2 = separatedString[1].ToCharArray();
            Array.Reverse(charArr1);
            Array.Reverse(charArr2);
            var str = string.Join(Convert.ToString(separator), new string(charArr1), new string(charArr2));
            return str;
        }

        public static void ReverseArray(ref int[] arr)
        {
            var buffer = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++) buffer[i] = arr[arr.Length - i - 1];

            arr = buffer;
        }

        public static void ReverseArray(ref int[] arr, out int[] revArr)
        {
            revArr = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++) revArr[i] = arr[arr.Length - i - 1];
        }

        public static void PrintArray(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++) Console.WriteLine($"Arr[{i}] = {arr[i]}");
        }

        private static void Main(string[] args)
        {
            int nums;
            while (true)
                try
                {
                    Console.Write("Введите какие-то числа: ");
                    nums = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Я буду просить ввести числа пока вы не введёте ЧИСЛА!");
                }

            var str = "ABCD";
            var magicStr = "ABCD.EFGH";
            var doNum = 123.456;
            var numsArr = new int[10] {1, 3, 5, 7, 9, 11, 13, 15, 17, 19};
            int[] reversedNumsArr;

            //Before reverse
            Console.WriteLine("Данные перед реверсом: ");
            Console.WriteLine(nums);
            Console.WriteLine(str);
            Console.WriteLine(magicStr);
            Console.WriteLine(doNum);
            PrintArray(numsArr);

            //After reverse
            Console.WriteLine();
            Console.WriteLine("Данные после реверса: ");
            Console.WriteLine(ReverseString(ref nums));
            Console.WriteLine(ReverseString(ref str));
            Console.WriteLine(ReverseString(ref doNum));
            Console.WriteLine(ReverseString(ref magicStr, '.'));

            Console.WriteLine("Реверс данных с помощью \"ref\"...");
            ReverseArray(ref numsArr);
            PrintArray(numsArr);

            Console.WriteLine("Реверс данных с помощью \"ref\" and with \"out\"");
            ReverseArray(ref numsArr, out reversedNumsArr);
            PrintArray(reversedNumsArr);

            Console.ReadKey();
        }
    }
}