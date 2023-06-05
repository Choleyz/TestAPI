using Domaine.Entities;
using Domaine.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Services
{
    public class UserService : IUserRepository
    {    
        private readonly IDbConnection _service;

        public UserService(IDbConnection service)
        {
            _service = service;
        }

        public IEnumerable<User> Handle()
        {
            using (SqlConnection connection = new SqlConnection(_service.ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM [User]";
                List<User> users = new List<User>();
                connection.Open();
                Console.WriteLine(connection.State);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Firstname = (string)reader[0],
                            Lastname = (string)reader[1],
                            Pseudo = (string)reader[2],
                            Email = (string)reader[3],
                            Password = (string)reader[4],
                            PhoneNumber = (string)reader[5],
                        });
                    }
                }
                connection.Close();
                return users;
            }
        }

    }
}
