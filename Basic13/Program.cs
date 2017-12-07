using System;

namespace ConsoleApplication
{
    class Program
    {
        public static void onetotwofiftyfive()
        {
            for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void oddonetotwofiftyfive()
        {
            for (int i = 1; i < 256; i = i + 2)
            {
                Console.WriteLine(i);
            }
        }
        public static void printSum()
        {
            int sum = 0;
            for (int i = 0; i < 256; i = i + 1)
            {
                sum += i;
                Console.WriteLine("New number: {0} Sum: {1}", i, sum);
            }
        }
        // public static void IterArray(int [] arr)
        // {
        //     foreach (int val in arr)
        //     {
        //         System.Console.WriteLine(val);
        //     }
        // }
        public static void findMax(int[]arr)
        {
            int max = arr[0];
            foreach (int val in arr)
            {
                if (val > max)
                {
                    max = val;
                }
            }

        }
        public static 
        public static void Main(string[] args)
        {
            // IterArray();
            onetotwofiftyfive();
            oddonetotwofiftyfive();
            printSum();
        }
    }
}
