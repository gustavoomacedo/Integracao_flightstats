using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Integracao_flightstats.Models
{
    [DataContract]
    public class AirlineData
    {
        [DataMember]
        public bool HasError { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<AirlineCustom> Airlines { get; set; }
    }
}