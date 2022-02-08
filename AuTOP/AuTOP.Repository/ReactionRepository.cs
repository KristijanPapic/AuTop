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
        public async Task<int> GetLikes()
        {
            string queryString = $"SELECT COUNT(ReviewId) FROM Reaction WHERE IsLiked!=0;";

            using (SqlConnection connection = new SqlConnection("Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                int numberOfLikes = 0;

                while (myReader.Read())
                {
                    numberOfLikes++;
                }
                myReader.Close();
                connection.Close();
                return numberOfLikes;

            }
        }

        public async Task<int> GetDislikes()
        {
            string queryString = $"SELECT COUNT(ReviewId) FROM Reaction WHERE IsLiked=0;";

            using (SqlConnection connection = new SqlConnection("Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=matej;Password=Sifra1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                int numberOfDislikes = 0;

                while (myReader.Read())
                {
                    numberOfDislikes++;
                }
                myReader.Close();
                connection.Close();
                return numberOfDislikes;


            }
        }
    }
}
