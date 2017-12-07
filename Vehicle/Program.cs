using System;

namespace ConsoleApplicaton
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Vehicle(2);
            Vehicle myBike = new Vehicle(1);
            Console.WriteLine(myCar.numPassenger);
            Console.WriteLine(myBike.numPassenger);
            myCar.Move(2.5);
            myBike.Move(5.0);
            Console.WriteLine("My Bike went {0} miles & my car went {1} miles", myBike.distance, myCar.distance);
        }
    }
}
