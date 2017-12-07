using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using Wall2.Models;

namespace Wall2.Factory
{
    public class MessageFactory : IFactory<Users>
    {
        private string connectionString;
        public MessageFactory()
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
        public void Add(Messages content)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO MESSAGES (Message, Created_at, Updated_at, User_id) VALUES ('{content.Message}','{content.created_at}','{content.updated_at}',) ";

                dbConnection.Open();
                dbConnection.Execute(query, content);
            }
        }
    }
} 