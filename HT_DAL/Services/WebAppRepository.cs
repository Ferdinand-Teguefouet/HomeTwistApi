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
    public class WebAppRepository : BaseRepository<WebApp>, IWebAppRepository
    {
        public WebAppRepository(IConfiguration config): base(config)
        {
        }
        public WebApp GetById(int id)
        {
            string query = "SELECT * FROM WebApp WHERE Id_WebApp = @id";
            Command cmd = new Command(query);
            cmd.AddParameter(nameof(WebApp.Id_WebApp), id);

            Connection connection = new Connection(_connectionString);
            return connection.ExecuteReader(cmd, Convert).FirstOrDefault();
        }
    }
}
