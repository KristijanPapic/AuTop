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
    }
}
