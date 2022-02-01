using HomeTwistApi.Models;
using HT_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTwistApi.Tools
{
    public static class Mappers
    {
        public static BusinessCustomer ToBLLCustomer(this CustomerModel cm)
        {
            return new BusinessCustomer()
            {
                Id_Customer = cm.Id_Customer,
                LastName = cm.LastName,
                FirstName = cm.FirstName,
                Phone = cm.Phone,
                Email = cm.Email,
                Password = cm.Password,
                Salt = cm.Salt,
                IsAdmin = cm.IsAdmin,
                Id_Country = cm.Id_Country,
                Id_WebApp = cm.Id_WebApp                
            };
        }
    }
}
