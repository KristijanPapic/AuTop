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
    public class TransmissionRepository : ITransmissionRepository
    {
        public async Task<List<Transmission>> GetAllAsync()
        {
            List<Transmission> transmissions = new List<Transmission>();
            string queryString = $"SELECT * FROM Transmission;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();

                while (myReader.Read())
                {
                    Transmission transmission = new Transmission();

                    transmission.Id = (Guid)myReader["Id"];
                    transmission.Name = myReader["Name"].ToString();
                    transmission.Gears = int.Parse(myReader["Gears"].ToString());
                    transmission.DateCreated = (DateTime)myReader["DateCreated"];
                    transmission.DateUpdated = (DateTime)myReader["DateUpdated"];

                    transmissions.Add(transmission);
                }
                myReader.Close();
                connection.Close();
                return transmissions;

            }

        }


        public async Task<Transmission> GetByIdAsync(int id)
        {
            string queryString = $"SELECT * FROM Transmission WHERE id={id};";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                Transmission transmission = new Transmission();
                while (myReader.Read())
                {

                    transmission.Id = (Guid)myReader["Id"];
                    transmission.Name = myReader["Name"].ToString();
                    transmission.Gears = int.Parse(myReader["Gears"].ToString());
                    transmission.DateCreated = (DateTime)myReader["DateCreated"];
                    transmission.DateUpdated = (DateTime)myReader["DateUpdated"];
                }
                connection.Close();
                return transmission;

            }
        }
    }
}
