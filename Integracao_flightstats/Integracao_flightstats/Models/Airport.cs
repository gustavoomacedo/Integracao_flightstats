using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Airport
    {
        public string fs { get; set; }
        public string iata { get; set; }
        public string icao { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string cityCode { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string regionName { get; set; }
        public string timeZoneRegionName { get; set; }
        public DateTime localTime { get; set; }
        public double utcOffsetHours { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int elevationFeet { get; set; }
        public int classification { get; set; }
        public bool active { get; set; }
        public string delayIndexUrl { get; set; }
        public string weatherUrl { get; set; }
        public string stateCode { get; set; }
    }

    public class Airports
    {
        public Airport[] airports { get; set; }
    }
}