using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall2.Models;

namespace Wall2.Factory
{
    public class UserFactory : IFactory<Users>
    {
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
                string query = $"INSERT INTO USERS (firstName, lastName, email, password) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}')";

                dbConnection.Open();
                dbConnection.Execute(query, user);
            }
        }
        public IEnumerable<Users> GetUserById(string userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Users>($"SELECT * FROM USERS where Id = '{userId}'");
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
        public IEnumerable<Messages> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Messages>("SELECT * FROM Messeges");
            }
        }
    }
}