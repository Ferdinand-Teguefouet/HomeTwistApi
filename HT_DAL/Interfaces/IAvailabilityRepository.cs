using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface IAvailabilityRepository
    {
        IEnumerable<Availability> GetAll();
        Availability GetById(int id);
        bool Insert(Availability a);
        bool Update(Availability a);
        void Delete(int id);
    }
}
