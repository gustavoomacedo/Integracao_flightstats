using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Countries
    {
        public Country[] countries { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string code { get; set; }
    }
}


