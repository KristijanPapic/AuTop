using AuTOP.Model;
using AuTOP.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        public async Task<double> GetLikes()
        {
            string queryStringLike = $"SELECT COUNT(ReviewId) FROM Reaction WHERE IsLiked!=0;";
            string queryStringDislike = $"SELECT COUNT(ReviewId) FROM Reaction WHERE IsLiked=0;";

            using (SqlConnection connection = new SqlConnection("Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                connection.Open();
                SqlCommand myCommandLike = new SqlCommand(queryStringLike, connection);
                SqlCommand myCommandDislike = new SqlCommand(queryStringDislike, connection);
                SqlDataReader myReaderLike = await myCommandLike.ExecuteReaderAsync();
                int numberOfLikes = 1;
                int numberOfDislikes = 1;

                while (myReaderLike.Read())
                {
                    numberOfLikes++;
                }

                myReaderLike.Close();
                SqlDataReader myReaderDislike = await myCommandDislike.ExecuteReaderAsync();

                while (myReaderDislike.Read())
                {
                    numberOfDislikes++;
                }

                myReaderDislike.Close();
                connection.Close();

                int numberOfLikesAndDislikes = numberOfDislikes + numberOfLikes;
                double percentageOfLikes = (double)numberOfLikes / numberOfLikesAndDislikes;
                double number = percentageOfLikes * 100;
                number = Math.Round(number, 2);
                return number;


            }
        }

        public async Task<bool> PostAsync(Reaction reaction)
        {
            reaction.DateCreated = DateTime.UtcNow;
            reaction.DateUpdated = DateTime.UtcNow;
           
            string insertSql = @"INSERT INTO Reaction(UserId, ReviewId, IsLiked, DateCreated, DateUpdated)
                     Values(@UserId, @ReviewId, @IsLiked, @DateCreated, @DateUpdated)";
            
            
            using (SqlConnection connection = new SqlConnection("Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
            try
                {
                    using (var com = new SqlCommand(insertSql, connection))
                    {
                        com.Parameters.AddWithValue("@UserId", reaction.UserId);
                        com.Parameters.AddWithValue("@ReviewId", reaction.ReviewId);
                        com.Parameters.AddWithValue("@IsLiked", reaction.IsLiked);
                        com.Parameters.AddWithValue("@DateCreated", reaction.DateCreated);
                        com.Parameters.AddWithValue("@DateUpdated", reaction.DateUpdated);
                        connection.Open();
                        await com.ExecuteNonQueryAsync();
                    }
                   
                    connection.Close();
                    return true;

                }
                catch (SqlException ex)
                {
                    return false;
                }

            }
        }
        
    }
}
