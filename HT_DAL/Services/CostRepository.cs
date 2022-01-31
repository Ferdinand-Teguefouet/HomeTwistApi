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
    public class CostRepository : BaseRepository<Cost>, ICostRepository
    {
        #region constructor
        public CostRepository(IConfiguration config) : base(config)
        {          
        } 
        #endregion

        #region GetAll method
        public IEnumerable<Cost> GetAll()
        {
            string query = "SELECT * FROM Cost";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        } 
        #endregion
    }
}
