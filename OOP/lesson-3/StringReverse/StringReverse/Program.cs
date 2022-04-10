using System;
using System.Text;

namespace StringReverse
{
    class Program
    {
        // public static string StringReverse3(string str)
        // {
        //     int len = str.Length;
        //     
        //     string newStr = "";
        //     while (len > 0)
        //     {
        //         newStr += str[--len];
        //     }
        //     
        //     return newStr;
        // }

        private static string StringReverse(string str)
        {
            if (str.Length == 0)
                return "";
            int len = str.Length;
            StringBuilder sb = new StringBuilder(len);
            while (len > 0)
                sb.Append(str[--len]);
            return sb.ToString();
        }
        
        // static public string StringReverse(string str)
        // {
        //     char c;
        //     for (int i = 0; i < str.Length / 2; i++)
        //     {
        //         c = str[i];
        //         str[i] = str[str.Length - i - 1];
        //         str[str.Length - i - 1] = c;
        //     }
        //     return str;
        // }

        static void Test(string s)
        {
            Console.WriteLine($"{s}={StringReverse(s)}");
        }
        
        static void Main()
        {
            Test("12345");
            Test("012345");
            Test("0");
            Test("01");
            Test("");
        }
    }
}