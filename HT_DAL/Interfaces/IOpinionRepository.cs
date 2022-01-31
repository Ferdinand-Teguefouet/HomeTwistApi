using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface IOpinionRepository
    {
        IEnumerable<Opinion> GetAll();
        Opinion GetById(int id);
        bool Insert(Opinion o);
        bool Update(Opinion o);
        void Delete(int id);
    }
}
