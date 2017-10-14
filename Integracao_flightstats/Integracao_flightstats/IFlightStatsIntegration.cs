using Integracao_flightstats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Integracao_flightstats
{
    [ServiceContract]
    public interface IFlightStatsIntegration
    {
        [OperationContract]
        FlightData GetFlightData(string airport, string year, string month, string day, string hour);

        [OperationContract]
        AirlineData GetAirlinesData();

        [OperationContract]
        AirportData GetAirportsData(string country);
        
    }
}
