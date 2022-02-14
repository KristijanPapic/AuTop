using AutoMapper;
using AuTOP.Common;
using AuTOP.Model.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AuTOP.Repository.Common;
using System.Text;

namespace AuTOP.Repository
{
    internal class ManufacturerRepository : IManufacturerRepository
    {

        private String connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public async Task<List<ManufacturerDomainModel>> GetAllManufacturers(ManufacturerFilter filter, Sorting sort, Paging paging)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            StringBuilder queryString = new StringBuilder("select * from Manufacturer");
            if(!String.IsNullOrWhiteSpace(filter.Name))
            {
                queryString.Append($" where Name like '%{filter.Name}%'");
            }
            if (!String.IsNullOrWhiteSpace(sort.SortBy))
            {
                queryString.Append($" order by { sort.SortBy} { sort.SortMethod}");
            }
            if(paging.DontPage == false)
            {
                queryString.Append($" offset { paging.GetStartElement()} rows fetch next {paging.Rpp} rows only;");
            }
            SqlCommand command = new SqlCommand(queryString.ToString(), connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet manufacturerData = new DataSet();
            await Task.Run(() => adapter.Fill(manufacturerData));
            List<ManufacturerDomainModel> manufacturers = new List<ManufacturerDomainModel>();
            if (manufacturerData.Tables[0].Rows.Count == 0)
            {
                return manufacturers;
            }

            foreach (DataRow dataRow in manufacturerData.Tables[0].Rows)
            {
                manufacturers.Add(new ManufacturerDomainModel{
                   Id =  Guid.Parse(Convert.ToString(dataRow["Id"])), 
                   Name = Convert.ToString(dataRow["Name"]), 
                   ImageURL = Convert.ToString(dataRow["ImageURL"]), 
                   DateCreated = Convert.ToDateTime(dataRow["DateCreated"]), 
                   DateUpdated = Convert.ToDateTime(dataRow["DateUpdated"])
                    });
            }
            return manufacturers;

        }
        public async Task<ManufacturerDomainModel> GetManufacturerByIdAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"select * from Manufacturer where Id = '{id}';";
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet manufacturerData = new DataSet();
            await Task.Run(() => adapter.Fill(manufacturerData));
            DataRow dataRow = manufacturerData.Tables[0].Rows[0];
            ManufacturerDomainModel domainManufacturer = new ManufacturerDomainModel {
                Id = Guid.Parse(Convert.ToString(dataRow["Id"])),
                Name = Convert.ToString(dataRow["Name"]),
                ImageURL = Convert.ToString(dataRow["ImageURL"]),
                DateCreated = Convert.ToDateTime(dataRow["DateCreated"]),
                DateUpdated = Convert.ToDateTime(dataRow["DateUpdated"])
            };
            return domainManufacturer;
        }

        public async Task PostManufacturerAsync(ManufacturerDomainModel manufacturer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"insert into manufacturer values('{manufacturer.Id}','{manufacturer.Name}',{manufacturer.DateCreated},{manufacturer.DateUpdated},{manufacturer.ImageURL});";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            await command.ExecuteNonQueryAsync();
            connection.Close();
        }

        public async Task PutManufacturerAsync(ManufacturerDomainModel manufacturer)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"update manufacturer set Name = {manufacturer.Name},ImageURL = '{manufacturer.ImageURL}' where Id = '{manufacturer.Id}'";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            await command.ExecuteNonQueryAsync();
            connection.Close();
        }

        public async Task DeleteManufacturerAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"delete from manufacturer where Id = '{id}'";
            SqlCommand command = new SqlCommand(queryString, connection);
            connection.Open();
            await command.ExecuteNonQueryAsync();
            connection.Close();
        }


    }
}
