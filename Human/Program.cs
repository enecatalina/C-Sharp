using System;

namespace ConsoleApplicaton
{
    class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human("SuperWoman");
            Human human2 = new Human("Batman",20,40,10,600);
            Human human3 = new Human("Spiderman");
            // System.Console.WriteLine(human1.name);
            System.Console.WriteLine("{0} strength is {1}", human1.name,human1.strength);
            System.Console.WriteLine(human2.health);
            human1.Attack(human3);
            System.Console.WriteLine(human3.health);

        } 
    }
}
