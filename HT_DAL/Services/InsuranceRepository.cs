using HT_DAL.Entities;
using HT_DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using MyADOLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Services
{
    public class InsuranceRepository : BaseRepository<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(IConfiguration config) : base(config)
        {
        }
        public IEnumerable<Insurance> GetAll()
        {
            string query = "SELECT * FROM Insurance";
            Command cmd = new Command(query);

            return Connect().ExecuteReader(cmd, Convert);
        }
    }
}
