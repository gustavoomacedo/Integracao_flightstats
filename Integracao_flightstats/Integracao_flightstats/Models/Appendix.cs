using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Appendix
    {
        public Airline[] airlines { get; set; }
        public Airport[] airports { get; set; }
        public Equipment[] equipments { get; set; }
    }
}