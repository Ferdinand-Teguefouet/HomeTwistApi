using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTwistApi.Models
{
    public class CustomerModel
    {
        public int Id_Customer { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public bool IsAdmin { get; set; }
        public int Id_Country { get; set; }
        public int Id_WebApp { get; set; }
    }
}
