using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Flightequipment
    {
        public string scheduledEquipmentIataCode { get; set; }
        public string actualEquipmentIataCode { get; set; }
        public string tailNumber { get; set; }
    }
}