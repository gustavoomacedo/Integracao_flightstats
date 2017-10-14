using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Operationaltimes
    {
        public Publisheddeparture publishedDeparture { get; set; }
        public Publishedarrival publishedArrival { get; set; }
        public Scheduledgatedeparture scheduledGateDeparture { get; set; }
        public Estimatedgatedeparture estimatedGateDeparture { get; set; }
        public Actualgatedeparture actualGateDeparture { get; set; }
        public Estimatedrunwaydeparture estimatedRunwayDeparture { get; set; }
        public Actualrunwaydeparture actualRunwayDeparture { get; set; }
        public Scheduledgatearrival scheduledGateArrival { get; set; }
        public Estimatedgatearrival estimatedGateArrival { get; set; }
        public Actualgatearrival actualGateArrival { get; set; }
        public Estimatedrunwayarrival estimatedRunwayArrival { get; set; }
        public Actualrunwayarrival actualRunwayArrival { get; set; }
    }
}