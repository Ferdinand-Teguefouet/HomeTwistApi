using HT_BLL.Models;
using HT_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_BLL.Tools
{
    public static class Mappers
    {
        public static BusinessCustomer ToHtBLLCustomer(this Customer cust)
        {
            if (cust == null) return null;

            return new BusinessCustomer
            {
                Id_Customer = cust.Id_Customer,
                LastName = cust.LastName,
                FirstName = cust.FirstName,
                Phone = cust.Phone,
                Email = cust.Email,
                Password = cust.Password,
                Salt = cust.Salt,
                IsAdmin = cust.IsAdmin,
                Id_Country = cust.Id_Country,
                Id_WebApp = cust.Id_WebApp,
                Deleted = cust.Deleted
            };
        }

        public static Customer ToHtDALCustomer(this BusinessCustomer bcust)
        {
            if (bcust == null) return null;

            return new Customer
            {
                Id_Customer = bcust.Id_Customer,
                LastName = bcust.LastName,
                FirstName = bcust.FirstName,
                Phone = bcust.Phone,
                Email = bcust.Email,
                Password = bcust.Password,
                Salt = bcust.Salt,
                IsAdmin = bcust.IsAdmin,
                Id_Country = bcust.Id_Country,
                Id_WebApp = bcust.Id_WebApp,
                Deleted = bcust.Deleted
            };
        }
    }
}
