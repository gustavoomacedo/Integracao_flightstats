using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracao_flightstats.Models
{
    public class Equipment
    {
        public string iata { get; set; }
        public string name { get; set; }
        public bool turboProp { get; set; }
        public bool jet { get; set; }
        public bool widebody { get; set; }
        public bool regional { get; set; }
    }
}