﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_DAL.Entities
{
    public class Country
    {
        public int Id_Country { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Name { get; set; }
    }
}
