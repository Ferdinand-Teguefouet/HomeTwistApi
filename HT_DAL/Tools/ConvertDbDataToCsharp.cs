using HT_DAL.Entities;
using HT_DAL.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Tools
{
    internal static class ConvertDbDataToCsharp
    {
        internal static Availability AvailabilityConverter(SqlDataReader reader)
        {
            return new Availability
            {
                Id = (int)reader["Id"],
                StardDate = (DateTime)reader["StartDate"],
                EndDate = (DateTime)reader["EndDate"]
            };
        }

        internal static Cost CostConverter(SqlDataReader reader)
        {
            return new Cost
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                Price = (decimal)reader["Price"]
            };
        }

        internal static Country CountryConverter(SqlDataReader reader)
        {
            return new Country
            {
                Id = (int)reader["Id"],
                Iso2 = reader["Iso2"].ToString(),
                Iso3 = reader["Iso3"].ToString(),
                Name = reader["Name"].ToString()
            };
        }

        internal static Insurance InsuranceConverter(SqlDataReader reader)
        {
            return new Insurance
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                Description = reader["Description"].ToString(),
                PricePerDay = (decimal)reader["PricePerDay"]
            };
        }

        internal static WebApp WebAppConverter(SqlDataReader reader)
        {
            return new WebApp
            {
                Id = (int)reader[nameof(WebApp.Id)],
                Name = reader[nameof(WebApp.Name)].ToString(),
                Address = reader[nameof(WebApp.Address)] is DBNull ? null : reader[nameof(WebApp.Address)].ToString(),
                Phone = reader[nameof(WebApp.Phone)] is DBNull ? null : reader[nameof(WebApp.Phone)].ToString(),
                Email = reader[nameof(WebApp.Email)] is DBNull ? null : reader[nameof(WebApp.Email)].ToString(),
                Country = reader[nameof(WebApp.Country)] is DBNull ? null : reader[nameof(WebApp.Country)].ToString()
            };
        }
    }
}
