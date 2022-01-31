using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Services
{
    public abstract class BaseRepository<T> where T:class
    {
        protected readonly string _connectionString;

        internal BaseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        protected Connection Connect()
        {
            return new Connection(_connectionString);
        }

        protected T Convert(SqlDataReader reader)
        {
            T retour = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo item in typeof(T).GetProperties())
            {
                item.SetValue(retour, reader[item.Name] != DBNull.Value ? reader[item.Name] : null);
            }
            return retour;
        }
    }
}
