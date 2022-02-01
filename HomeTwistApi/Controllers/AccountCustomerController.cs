using HomeTwistApi.Models;
using HomeTwistApi.Tools;
using HT_BLL.Interfaces;
using HT_BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTwistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCustomerController : ControllerBase
    {

        private readonly IBusinessCustomer<BusinessCustomer> _custService;


        public AccountCustomerController(IBusinessCustomer<BusinessCustomer> bCustomer)
        {
            _custService = bCustomer;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register(CustomerModelForm customerForm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Erreur d'enregistrement!");

                //Hash password
                byte[] salt = PasswordTools.GenerateSalt();

                CustomerModel cm = new CustomerModel()
                {
                    LastName = customerForm.LastName,
                    FirstName = customerForm.FirstName,
                    Phone = customerForm.Phone,
                    Email = customerForm.Email,
                    Password = PasswordTools.GenerateSaltedHash(System.Text.Encoding.UTF8.GetBytes(customerForm.Password), salt),
                    Salt = salt,
                    IsAdmin = false,
                    Id_Country = customerForm.Id_Country,
                    Id_WebApp = 1
                };

                _custService.Insert(cm.ToBLLCustomer());
                return NoContent();
            }
            catch (Exception ex)
            {
                //logger l'exception
                return BadRequest(ex.Message);
            }
        }
    }
}
