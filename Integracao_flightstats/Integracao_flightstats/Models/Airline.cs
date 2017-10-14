using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Airline
    {
        public string fs { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string phoneNumber { get; set; }
    }

    public class Airlines
    {
        public Airline[] airlines { get; set; }
    }
}


