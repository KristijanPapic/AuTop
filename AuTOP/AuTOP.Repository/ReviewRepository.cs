using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuTOP.Repository.Common;
using AuTOP.Model.Common;
using System.Data.SqlClient;
using AuTOP.Model;
using AuTOP.Common;

namespace AuTOP.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        static string connecitonString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;" +
            "Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public async Task<List<IReview>> GetAsync(ReviewFilter filter)
        {
            List<IReview> reviews = new List<IReview>();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query;
                if (filter.Search == Guid.Empty)
                {
                    query = "SELECT * FROM [Review]";
                }
                else
                {
                    query = $"SELECT * FROM [Review] where {filter.SearchBy} = '{filter.Search}'";
                }
                SqlCommand command;

                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    Review review = new Review()
                    {
                        ReviewId = (Guid)reader["Id"],
                        UserId = (Guid)reader["UserId"],
                        ModelVersionId = (Guid)reader["ModelVersionID"],
                        Comment = reader["Comment"].ToString(),
                        Rating = (int)reader["Rating"],
                        DateCreated = (DateTime)reader["DateCreated"],
                        DateUpdated = (DateTime)reader["DateUpdated"]
                    };
                    reviews.Add(review);
                }

                reader.Close();
                connection.Close();
            }
            return reviews;
        }

        public async Task<IReview> GetByIdAsync(Guid reviewId)
        {
            Review review = new Review();
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                string query = $"SELECT * FROM [Review] WHERE Id = '{reviewId}';";
                SqlCommand command;

                command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                reader.Read();


                review.ReviewId = (Guid)reader["Id"];
                review.UserId = (Guid)reader["UserId"];
                review.ModelVersionId = (Guid)reader["ModelVersionID"];
                review.Comment = reader["Comment"].ToString();
                review.Rating = (int)reader["Rating"];
                review.DateCreated = (DateTime)reader["DateCreated"];
                review.DateUpdated = (DateTime)reader["DateUpdated"];

                reader.Close();
                connection.Close();
            }
            return review;
        }
        public async Task PostAsync(IReview review)
        {
            using (SqlConnection connection = new SqlConnection(connecitonString))
            {
                SqlCommand command = new SqlCommand(
                  $"INSERT INTO [Review] VALUES (NEWID(),'{review.ModelVersionId}','{review.UserId}','{review.Comment}','{review.Rating}',GETDATE(),GETDATE())", connection);

                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

    }
}
