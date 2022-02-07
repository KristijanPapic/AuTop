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
    class MotorRepository : IMotorRepository
    {
        public async Task<List<Motor>> GetAllAsync()
        {
            List<Motor> motors = new List<Motor>();
            string queryString = $"SELECT * FROM Motor;";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();

                while (myReader.Read())
                {
                    Motor motor = new Motor();

                    motor.Id = (Guid)myReader["Id"];
                    motor.Year = int.Parse(myReader["Year"].ToString());
                    motor.Type = myReader["Type"].ToString();
                    motor.MaxHP = int.Parse(myReader["MaxHP"].ToString());
                    motor.EngineSize = int.Parse(myReader["EngineSize"].ToString());
                    motor.Name = myReader["Name"].ToString();
                    motor.DateCreated = (DateTime)myReader["DateCreated"];
                    motor.DateUpdated = (DateTime)myReader["DateUpdated"];

                    motors.Add(motor);
                }
                myReader.Close();
                connection.Close();
                return motors;

            }

        }


        public async Task<Motor> GetByIdAsync(Guid id)
        {
            string queryString = $"SELECT * FROM Motor WHERE id={id};";

            using (SqlConnection connection = new SqlConnection("Server = localhost; Database = webapi; Trusted_Connection = True;"))
            {

                connection.Open();
                SqlCommand myCommand = new SqlCommand(queryString, connection);
                SqlDataReader myReader = await myCommand.ExecuteReaderAsync();
                Motor motor = new Motor();
                while (myReader.Read())
                {
                    motor.Id = (Guid)myReader["Id"];
                    motor.Year = int.Parse(myReader["Year"].ToString());
                    motor.Type = myReader["Type"].ToString();
                    motor.MaxHP = int.Parse(myReader["MaxHP"].ToString());
                    motor.EngineSize = int.Parse(myReader["EngineSize"].ToString());
                    motor.Name = myReader["Name"].ToString();
                    motor.DateCreated = (DateTime)myReader["DateCreated"];
                    motor.DateUpdated = (DateTime)myReader["DateUpdated"];
                }
                connection.Close();
                return motor;

            }
        }
    }
}
