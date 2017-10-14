using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Integracao_flightstats.Models
{
    [DataContract]
    public class FlightData
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Arrival Arrival { get; set; }
        [DataMember]
        public Departure Departure { get; set; }
    }
}
