using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByEmail(string email);
        bool Insert(Customer c);
        bool Update(Customer c);
        void Delete(int id);
    }
}
