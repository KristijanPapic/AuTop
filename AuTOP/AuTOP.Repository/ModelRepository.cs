using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    internal class ModelRepository : IModelRepository
    {
        private String connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<List<ModelDomainModel>> GetAllModelsAsync(ModelFilter filter, Sorting sort, Paging paging)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            string queryString;
            if (filter.Search == "")
            {
                queryString = "select * from model";
                command = new SqlCommand(queryString, connection);
            }
            else
            {
                queryString = $"select * from model where {filter.SearchBy} like '%{filter.Search}%'";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FILTER", "%" + filter.Search + "%");
            }
            if (!(sort.SortBy == ""))
            {
                command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" order by { sort.SortBy} { sort.SortMethod}");
            }

            command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" offset { paging.GetStartElement()} rows fetch next {paging.Rpp} rows only;");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet modelData = new DataSet();
            await Task.Run(() => adapter.Fill(modelData));
            List<ModelDomainModel> models = new List<ModelDomainModel>();
            if (modelData.Tables[0].Rows.Count == 0)
            {
                return models;
            }

            foreach (DataRow dataRow in modelData.Tables[0].Rows)
            {
                models.Add(new ModelDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Guid.Parse(Convert.ToString(dataRow["ManufacturerId"])), Convert.ToString(dataRow["Name"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"])));
            }
            return models;

        }

        public async Task<List<ModelDomainModel>> GetModelsByManufacturer(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            string queryString;
            queryString = $"select * from model where ManufacturerId = '{id}'";
            command = new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet modelData = new DataSet();
            await Task.Run(() => adapter.Fill(modelData));
            List<ModelDomainModel> models = new List<ModelDomainModel>();
            if (modelData.Tables[0].Rows.Count == 0)
            {
                return models;
            }

            foreach (DataRow dataRow in modelData.Tables[0].Rows)
            {
                models.Add(new ModelDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Guid.Parse(Convert.ToString(dataRow["ManufacturerId"])), Convert.ToString(dataRow["Name"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"])));
            }
            return models;

        }
    }
}
