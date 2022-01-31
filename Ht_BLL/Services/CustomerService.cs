using HT_BLL.Interfaces;
using HT_BLL.Models;
using HT_BLL.Tools;
using HT_DAL.Entities;
using HT_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_BLL.Services
{
    public class CustomerService : IBusinessCustomer<BusinessCustomer>
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customer)
        {
            _customerRepo = customer;
        }

        public void Delete(int id)
        {
            _customerRepo.Delete(id);
        }

        public IEnumerable<BusinessCustomer> GetAll()
        {
            return _customerRepo.GetAll().Select(Cust => Cust.ToHtBLLCustomer());
        }

        public BusinessCustomer GetByEmail(string email)
        {
            return _customerRepo.GetByEmail(email).ToHtBLLCustomer();
        }

        public BusinessCustomer GetById(int id)
        {
            return _customerRepo.GetById(id).ToHtBLLCustomer();
        }

        public void Insert(BusinessCustomer t)
        {
            _customerRepo.Insert(t.ToHtDALCustomer());
        }

        public void Update(BusinessCustomer t)
        {
            _customerRepo.Update(t.ToHtDALCustomer());
        }
    }
}
