using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Entities
{
    public class Opinion
    {
        public int Id_Opinion { get; set; }
        public string   Description { get; set; }
        public int Note { get; set; }
        public Boolean IsValidate { get; set; }
        public int Id_Property { get; set; }
        public int Id_Customer { get; set; }
    }
}
