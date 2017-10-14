using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Schedule
    {
        public string flightType { get; set; }
        public string serviceClasses { get; set; }
        public string restrictions { get; set; }
    }
}