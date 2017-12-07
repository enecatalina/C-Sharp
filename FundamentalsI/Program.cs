using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Loop that prints all values from 1 - 255
            // for (int i = 1; i < 256 ; i++)
            // System.Console.WriteLine(i);


            // Create a new loop that prints all values from 1 - 100 that are divisible by 3 or 5, but not both
            // for (int i = 1; i < 101; i++){
            //     if(!(i % 15 == 0)){
            //         if (i % 3 == 0 || i% 5 == 0){
            //             Console.WriteLine(i);
            //         }
            //     }
            // }

            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
            // for(int i = 1; i < 100; i++){
            // if (i % 3 == 0 && i % 5 == 0)
            //     {
            //         System.Console.WriteLine("FizzBuzz" + i);
            //     }
            // else if ( i % 3 == 0)
            //     {
            //     System.Console.WriteLine("Fizz"+ i);
            //     }
            // else if ( i % 5 == 0)
            //     {
            //     System.Console.WriteLine("Buzz" + i);
            //     }
            // }

            // Generate 10 random values and output the respective word, in relation to step three, for the generated values
            Random rand = new Random();
            for (int num = 0; num <= 10; num++)
            {
                int val = rand.Next(1, 100);

                string output = "For attempt " + num + " the value is " + val + " and the word is ";

                if (val % 3 == 0 && val % 5 == 0)
                {
                    output += "FizzBuzz";
                }
                else if (val % 3 == 0)
                {
                    output += "Fizz";
                }
                else if (val % 5 == 0)
                {
                    output += "Buzz";
                }
                else
                {
                    output += "it is not 5 or 3";
                }

                Console.WriteLine(output);
            }
        }
    }
}
