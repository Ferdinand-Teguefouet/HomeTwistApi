using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Entities
{
    public class Property
    {
        public int Id_Property { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public int Person { get; set; }
        public int BathRoom { get; set; }
        public int WC { get; set; }
        public Boolean Garden { get; set; }
        public Boolean Pool { get; set; }
        public Boolean Washing { get; set; }
        public Boolean Internet { get; set; }
        public Boolean Pets { get; set; }
        public Boolean Status { get; set; }
        public Boolean InactiveDate { get; set; }
        public Boolean IsInsurance { get; set; }
        public int Id_Country { get; set; }
        public int Id_Customer { get; set; }
    }
}
