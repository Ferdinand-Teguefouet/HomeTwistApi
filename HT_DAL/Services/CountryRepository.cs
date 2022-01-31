using HT_DAL.Entities;
using HT_DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Services
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        #region constructor
        public CountryRepository(IConfiguration config) : base(config)
        {
        }
        #endregion

        #region GetAll method
        public IEnumerable<Country> GetAll()
        {
            string query = "SELECT * FROM Country";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        }
        #endregion

        #region GetById method
        public Country GetById(int id)
        {
            string query = "SELECT * FROM Country WHERE Id_Country = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("Id_Country", id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        } 
        #endregion
    }
}
