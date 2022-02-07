using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuTOP.Repository
{
    public class ModelVersionRepository
    {
        private String connectionString = "Server=tcp:monoprojektdbserver.database.windows.net,1433;Initial Catalog=monoprojekt;Persist Security Info=False;User ID=kristijan;Password=Robinhoodr52600;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public async Task<List<ManufacturerDomainModel>> GetAllModelVersions(ManufacturerFilter filter, Sorting sort, Paging paging)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            string queryString;
            if (filter.Search == "")
            {
                queryString = "select * from Manufacturer";
                command = new SqlCommand(queryString, connection);
            }
            else
            {
                queryString = "select * from Manufacturer where Name like @FILTER";
                command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FILTER", "%" + filter.Search + "%");
            }
            if (!(sort.SortBy == ""))
            {
                command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" order by { sort.SortBy} { sort.SortMethod}");
            }

            command.CommandText = command.CommandText.Insert(command.CommandText.Length, $" offset { paging.GetStartElement()} rows fetch next {paging.Rpp} rows only;");
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
                manufacturers.Add(new ManufacturerDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"])));
            }
            return manufacturers;

        }
        public async Task<ManufacturerDomainModel> GetModelVersionById(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string queryString = $"select * from Manufacturer where Name = {name};";
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet manufacturerData = new DataSet();
            await Task.Run(() => adapter.Fill(manufacturerData));
            DataRow dataRow = manufacturerData.Tables[0].Rows[0];
            ManufacturerDomainModel domainManufacturer = new ManufacturerDomainModel(Guid.Parse(Convert.ToString(dataRow["Id"])), Convert.ToString(dataRow["Name"]), Convert.ToDateTime(dataRow["DateCreated"]), Convert.ToDateTime(dataRow["DateUpdated"]));
            return domainManufacturer;
        }

    }
}
}
