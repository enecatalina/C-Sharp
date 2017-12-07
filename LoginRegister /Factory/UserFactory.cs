using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LoginRegister.Models;
//The following using statements are required for db settings injection:
using Microsoft.Extensions.Options;

namespace LoginRegister.Factory
{
    public class UserFactory : IFactory<Users>
    {
        //private string connectionString;
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=Users;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public void Register(RegisterViewModel user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO USERS (FirstName, LastName, Email, Password) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.RegisterPassword}')";

                dbConnection.Open();
                dbConnection.Execute(query, user);
            }
        }
        public Users GetUserByEmail(string email)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Users>($"SELECT * FROM USERS where Email = '{email}'").FirstOrDefault();
            }
        }
    }
}