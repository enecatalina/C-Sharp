using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using DbConnection;

namespace CRUD_With_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname = "";
            string lname = "";
            string favNum = "";
           

            // UPDATE USER IN THE QUERY 
            // System.Console.Write("Please enter the ID of the record you updated ");
            // updatedID = System.Console.ReadLine();
            // string selectQuery = $"select * from users where id = {updatedID}";
            // List<Dictionary<string, object>> result = DbConnector.Query(selectQuery);

            // if (result.Count > 0)
            // {
            //     System.Console.Write("I found that ID...Now what is your first name? :");
            // }
            // fname = System.Console.ReadLine();
            // System.Console.WriteLine("Now tell me the new last name");
            // lname = System.Console.ReadLine();
            // System.Console.WriteLine("Now what is your upadted fav number:");
            // favNum = System.Console.ReadLine();

            // string updateQuery = $"updated ysers set FirstName = '{fname}', LastName '{lname}', FavoriteNumber = {favNum} Where id = {updatedID}";
            // DbConnector.Query(updateQuery);

            // System.Console.WriteLine("Updated!");


            //CREATING A NEW USER
            System.Console.Write("Please Enter you first name:");
            fname = System.Console.ReadLine();
            System.Console.WriteLine();
            System.Console.Write("Please Enter you last name:");
            fname = System.Console.ReadLine();
            System.Console.WriteLine();
            System.Console.Write("Please Enter you favorite number:");
            fname = System.Console.ReadLine();
            System.Console.WriteLine();


            string query = $"insert into Users (FirstName,LastName, FavoriteNumber) VALUES ('{fname}','{lname}', {favNum})";
            DbConnector.Execute(query);


        //    List<Dictionary<string, object>> allResults = DbConnector.Query("SELECT * FROM consoledb.users"); //selecting everything from the database
        //    foreach (Dictionary<string, object> item in allResults) // looping the database
        //     {
        //         System.Console.WriteLine("{0}---{1} {2}---{3}", item["id"], item["FirstName"], item["LastName"], item["FavoriteNumber"]);
        //     }
    
        }
    }
}



