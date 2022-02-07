using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Model.Common;
using AuTOP.Model;
using AuTOP.Repository.Common;

namespace AuTOP.Repository 
{
    public class UserRepository : IUserRepository
    {
        static string connecitonString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;" +
            "Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<List<IUser>> Get()
        {
            List<IUser> students = new List<IUser>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = "SELECT * FROM [User]";
                SqlCommand command;
                
                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User()
                    {
                        UserId = (Guid)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateCreated = (DateTime)reader["DateCreated"],
                        DateUpdated = (DateTime)reader["DateUpdated"]
                    };
                    students.Add(user);
                }

                reader.Close();
                connection.Close();
            }
            return students;
        }

        public async Task<List<IUser>> GetById(Guid userId)
        {
            List<IUser> students = new List<IUser>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = $"SELECT * FROM [User] WHERE Id = '{userId}';";
                SqlCommand command;

                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User()
                    {
                        UserId = (Guid)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateCreated = (DateTime)reader["DateCreated"],
                        DateUpdated = (DateTime)reader["DateUpdated"]
                    };
                    students.Add(user);
                }

                reader.Close();
                connection.Close();
            }
            return students;
        }

        public async Task Post(IUser user)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  $"INSERT INTO dbo.Student VALUES (NEWID(),@Username,@Password,@Email,'761B13B6-699D-45EF-9EFB-E31D352BC476',GETDATE(),GETDATE())", connection);

                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
