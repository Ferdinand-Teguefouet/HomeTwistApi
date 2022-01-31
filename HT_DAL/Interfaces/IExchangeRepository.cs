using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface IExchangeRepository
    {
        IEnumerable<Exchange> GetAll();
        Exchange GetById(int id);
        bool Insert(Exchange e);
        bool Update(Exchange e);
        void Delete(int id);
    }
}
