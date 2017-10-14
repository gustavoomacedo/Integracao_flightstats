using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Integracao_flightstats.Models
{
    [DataContract]
    public class AirportData
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<AirportCustom> Airports { get; set; }
    }
}