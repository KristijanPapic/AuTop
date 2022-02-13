using AuTOP.Common;
using AuTOP.Model;
using AuTOP.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    public class ModelVersionRepository : IModelVersionRepository
    {

        private String connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public async Task<List<ModelVersion>> GetAllModelVersions(ModelVersionFilter filter,Sorting sort, Paging paging)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            StringBuilder queryString = new StringBuilder("select * from ModelVersion where 1=1");

            if (!String.IsNullOrWhiteSpace(filter.Name))
            {
                queryString.Append($" and Name Like '%{filter.Name}%'");
            }
            
            if(filter.ModelId.HasValue)
            {
                queryString.Append($" and ModelId = '{filter.ModelId}'");
            }
            if (filter.MotorId.HasValue)
            {
                queryString.Append($" and MotorId = '{filter.MotorId}'");
            }
            if (filter.TransmissionId.HasValue)
            {
                queryString.Append($" and TransmissionId = '{filter.TransmissionId}'");
            }
            if (filter.BodyShapeId.HasValue)
            {
                queryString.Append($" and BodyShapeId = '{filter.BodyShapeId}'");
            }


            if (!String.IsNullOrWhiteSpace(sort.SortBy))
            {
                queryString.Append($" order by { sort.SortBy} { sort.SortMethod}");
            }
            if (paging.DontPage == false)
            {
                queryString.Append($" offset {paging.GetStartElement()} rows fetch next {paging.Rpp} rows only;");
            }
            SqlCommand command = new SqlCommand(queryString.ToString(), connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet modelVersionData = new DataSet();
            await Task.Run(() => adapter.Fill(modelVersionData));
            List<ModelVersion> modelVersions = new List<ModelVersion>();
            if (modelVersionData.Tables[0].Rows.Count == 0)
            {
                return modelVersions;
            }

            foreach (DataRow dataRow in modelVersionData.Tables[0].Rows)
            {
                modelVersions.Add(new ModelVersion
                {
                    Name = Convert.ToString(dataRow["Name"]),
                    Id = Guid.Parse(Convert.ToString(dataRow["Id"])),
                    ModelId = Guid.Parse(Convert.ToString(dataRow["ModelId"])),
                    MotorId = Guid.Parse(Convert.ToString(dataRow["MotorId"])),
                    BodyShapeId = Guid.Parse(Convert.ToString(dataRow["BodyShapeId"])),
                    TransmissionId = Guid.Parse(Convert.ToString(dataRow["TransmissionId"])),
                    FuelConsumption = Convert.ToDecimal(dataRow["FuelConsumption"]),
                    Year = Convert.ToInt32(dataRow["Year"]),
                    Acceleration = Convert.ToDecimal(dataRow["Acceleration"]),
                    Doors = Convert.ToInt32(dataRow["Doors"]),
                    DateCreated = Convert.ToDateTime(dataRow["DateCreated"]),
                    DateUpdated = Convert.ToDateTime(dataRow["DateUpdated"])
                });
            }
            return modelVersions;

        }
        public async Task<ModelVersion> GetModelVersionById(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"select * from ModelVersion where Id = '{id}';";
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet modelVersionData = new DataSet();
            await Task.Run(() => adapter.Fill(modelVersionData));
            DataRow dataRow = modelVersionData.Tables[0].Rows[0];
            ModelVersion modelVersion = new ModelVersion
            {
                Name = Convert.ToString(dataRow["Name"]),
                Id = Guid.Parse(Convert.ToString(dataRow["Id"])),
                ModelId = Guid.Parse(Convert.ToString(dataRow["ModelId"])),
                MotorId = Guid.Parse(Convert.ToString(dataRow["MotorId"])),
                BodyShapeId = Guid.Parse(Convert.ToString(dataRow["BodyShapeId"])),
                TransmissionId = Guid.Parse(Convert.ToString(dataRow["TransmissionId"])),
                FuelConsumption = Convert.ToDecimal(dataRow["FuelConsumption"]),
                Year = Convert.ToInt32(dataRow["Year"]),
                Acceleration = Convert.ToDecimal(dataRow["Acceleration"]),
                Doors = Convert.ToInt32(dataRow["Doors"]),
                DateCreated = Convert.ToDateTime(dataRow["DateCreated"]),
                DateUpdated = Convert.ToDateTime(dataRow["DateUpdated"])
            };
            return modelVersion;
        }


    }
}

