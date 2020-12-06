using System;
using System.Collections.Generic;
using System.Linq;

namespace L10
{
    public static class Extension
    {
        public static int ReverseString(this int nums)
        {
            var str = nums.ToString();
            var charArr = str.ToCharArray();
            Array.Reverse(charArr);
            str = new string(charArr);
            return Convert.ToInt32(str);
        }

        public static string ReverseString(this string str)
        {
            var charArr = str.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr);
        }

        public static double ReverseString(this double doStr)
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

        public static void ReverseArray(this int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                var tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
        }

        public static void ReplaceElems(this int[] arr)
        {
            int maxValue;
            List<int> list = new List<int>(arr.ToList());
            list.Sort();
            maxValue = list.Max();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    arr[i] = maxValue;
                }
            }
        }
    }
}