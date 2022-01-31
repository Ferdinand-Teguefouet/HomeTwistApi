using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface ICostRepository
    {
        IEnumerable<Cost> GetAll();
    }
}
