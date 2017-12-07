using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays

            // Create an array to hold integer values 0 through 9
            // iint[] valArray = new int[10] {0,1,2,3,4,5,6,7,8,9};

            // Create an array of the names "Tim", "Martin", "Nikki", &"Sara"
            // string[] myNames = new string[4] {"Time", "Martin","Nikki","Sara"};


            // Create an array of length 10 that alternates between true and false values, starting with true
            // bool[] boolArray = new bool[10];
            // for (int i = 0; i < 10; i ++)
            // {
            //     if (i % 2 == 0){
            //         boolArray[i] = true;
            //     }
            //     else if (i % 2 == 0){
            //     boolArray[i] = false;
            //     }   
            //     System.Console.WriteLine(boolArray[i]);
            // }
            //Multiplication table
            // int[,] mult = new int[10, 10];
            // for (int x = 0; x < 10; x++)
            // {
            //     for (int y = 0; y < 10; y++)
            //     {
            //         mult[x, y] = (x + 1) * (y + 1);
            //     }
            // }
            // for (int x = 0; x < 10; x++)
            // {
            //     string display = "[ ";
            //     for (int y = 0; y < 10; y++)
            //     {
            //         display += mult[x, y] + ", ";
            //         //Add an extra space for single digit values
            //         if (mult[x, y] < 10)
            //         {
            //             display += " ";
            //         }
            //     }
            //     display += "]";
            //     Console.WriteLine(display);
            // }


            // List of Flavors

            // Create a list of Ice Cream flavors that holds at least 5 different flavors(feel free to add more than 5!)
            List<string> iceCream = new List<string>();
            iceCream.Add("Chocolate");
            iceCream.Add("Vanilla");
            iceCream.Add("Cookie Dough");
            iceCream.Add("Oreo");
            iceCream.Add("Chocolate Trinity");
            
            // {
            //     System.Console.WriteLine(iceCream.Count);       //Output the length of the list 

            //     System.Console.WriteLine("Third ice cream flavor of the list" + iceCream[2]);   // thirs ice cream flavor in the list

            //     iceCream.RemoveAt(2);                   // removing from a list 

            //     System.Console.WriteLine(iceCream.Count);
            // }
            // User Info Dictionary
            // Create a Dictionary that will store both string keys as well as string valuesx
            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            Random rand = new Random();

            foreach (string name in newArray)
            {
                userInfo[name] = iceCream[rand.Next(iceCream.Count)];
            }
                System.Console.WriteLine(userInfo);
            // //Looping through info Dictionary
            // Console.WriteLine("Users and their favor ice cream flavors:");
            // foreach (KeyValuePair<string, string> info in userInfo)
            // {
            //     Console.WriteLine(info.Key + " - " + info.Value);
            // }
            // For each name key, select a random flavor from the flavor list above and store it as the value
            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
        }
    }
}

