using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Entities
{
    public class Exchange
    {
        public int Id_Exchange { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsAccepted { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public int Id_Cost { get; set; }
        public int Id_Insurance { get; set; }
        public int Id_Property { get; set; }
        public int Id_Customer { get; set; }
        public char Deleted { get; set; }
    }
}
