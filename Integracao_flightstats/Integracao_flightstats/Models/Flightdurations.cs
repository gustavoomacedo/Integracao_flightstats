using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Flightdurations
    {
        public int scheduledBlockMinutes { get; set; }
        public int blockMinutes { get; set; }
        public int airMinutes { get; set; }
        public int taxiOutMinutes { get; set; }
        public int taxiInMinutes { get; set; }
    }
}