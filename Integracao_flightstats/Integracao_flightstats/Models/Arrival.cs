using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Arrival
    {
        public Appendix Appendix { get; set; }
        public FlightStatus[] flightStatuses { get; set; }
    }
}