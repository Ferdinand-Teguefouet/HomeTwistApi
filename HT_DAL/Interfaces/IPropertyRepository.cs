using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetById(int id);
        bool Insert(Property p);
        bool Update(Property p);
        void Delete(int id);
    }
}
