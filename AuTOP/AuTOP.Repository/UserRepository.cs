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

        public async Task<List<IUser>> GetAsync()
        {
            List<IUser> students = new List<IUser>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = "SELECT * FROM [User]";
                SqlCommand command;
                
                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

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

        public async Task<IUser> GetByIdAsync(Guid userId)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = $"SELECT * FROM [User] WHERE Id = '{userId}';";
                SqlCommand command;

                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                reader.Read();


                user.UserId = (Guid)reader["Id"];
                user.Username = reader["Username"].ToString();
                user.Email = reader["Email"].ToString();
                user.DateCreated = (DateTime)reader["DateCreated"];
                user.DateUpdated = (DateTime)reader["DateUpdated"];                

                reader.Close();
                connection.Close();
            }
            return user;
        }

        public async Task PostAsync(IUser user)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  $"INSERT INTO [User] VALUES (NEWID(),'{user.Username}','{user.Password}','{user.Email}','761B13B6-699D-45EF-9EFB-E31D352BC476',GETDATE(),GETDATE())", connection);

                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task PutAsync(Guid userId, IUser user)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  $"UPDATE [User] SET Username='{user.Username}', Password='{user.Password}', Email='{user.Email}', DateUpdated=GETDATE() WHERE Id='{userId}'", connection);

                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task DeleteAsync(Guid userId)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  $"DELETE FROM [User] WHERE Id='{userId}'", connection);

                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }
    }
}
