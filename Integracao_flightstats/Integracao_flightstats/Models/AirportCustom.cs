using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class AirportCustom
    {
        public string iata { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string countryName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}