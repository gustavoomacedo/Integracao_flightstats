using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class FlightStatus
    {
        public int flightId { get; set; }
        public string carrierFsCode { get; set; }
        public string flightNumber { get; set; }
        public string departureAirportFsCode { get; set; }
        public string arrivalAirportFsCode { get; set; }
        public Departuredate departureDate { get; set; }
        public Arrivaldate arrivalDate { get; set; }
        public string status { get; set; }
        public Schedule schedule { get; set; }
        public Operationaltimes operationalTimes { get; set; }
        public Delays delays { get; set; }
        public Flightdurations flightDurations { get; set; }
        public Airportresources airportResources { get; set; }
        public Flightequipment flightEquipment { get; set; }
        public Codeshare[] codeshares { get; set; }
    }
}