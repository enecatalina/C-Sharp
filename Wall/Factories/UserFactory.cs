using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall.Models;

namespace Wall.Factory
{
    public class UserFactory : IFactory<Users> // Users = to database name 
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
                string query = $"INSERT INTO USER (firstName, lastName, email, password) VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Password}')";

                dbConnection.Open();
                dbConnection.Execute(query, user);
            }
        }
        public IEnumerable<Users> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Users>("SELECT * FROM users");
            }
        }
        public Users FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Users>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }
}