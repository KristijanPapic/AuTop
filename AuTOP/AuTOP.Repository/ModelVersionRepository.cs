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
            SqlCommand command;
            if(filter.SearchId == Guid.Empty)
            {
                string queryString = "select * from ModelVersion";
                command = new SqlCommand(queryString, connection);
            }
            else
            {
                string queryString = $"select * from ModelVersion where {filter.SearchBy} = '{filter.SearchId}'";
                command = new SqlCommand(queryString, connection);
            }
            if (!(sort.SortBy == ""))
            {
                command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" order by { sort.SortBy} { sort.SortMethod}");
            }
            if (paging.DontPage == false)
            {
                command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" offset { paging.GetStartElement()} rows fetch next {paging.Rpp} rows only;");
            }
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
                modelVersions.Add(new ModelVersion(Guid.Parse(Convert.ToString(dataRow["Id"])), Guid.Parse(Convert.ToString(dataRow["ModelId"])), Guid.Parse(Convert.ToString(dataRow["MotorId"])), Guid.Parse(Convert.ToString(dataRow["BodyShapeId"])), Guid.Parse(Convert.ToString(dataRow["TransmissionId"])), Convert.ToDecimal(dataRow["FuelConsumption"]), Convert.ToInt32(dataRow["Year"]), Convert.ToDecimal(dataRow["Acceleration"]), Convert.ToInt32(dataRow["Doors"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"])));
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
            ModelVersion modelVersion = new ModelVersion(Guid.Parse(Convert.ToString(dataRow["Id"])), Guid.Parse(Convert.ToString(dataRow["ModelId"])), Guid.Parse(Convert.ToString(dataRow["MotorId"])), Guid.Parse(Convert.ToString(dataRow["BodyShapeId"])), Guid.Parse(Convert.ToString(dataRow["TransmissionId"])), Convert.ToDecimal(dataRow["FuelConsumption"]), Convert.ToInt32(dataRow["Year"]), Convert.ToDecimal(dataRow["Acceleration"]), Convert.ToInt32(dataRow["Doors"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"])); 
            return modelVersion;
        }


    }
}

