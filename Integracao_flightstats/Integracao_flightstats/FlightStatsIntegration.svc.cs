using Integracao_flightstats.Models;
using Integracao_flightstats.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Integracao_flightstats
{
    public class FlightStatsIntegration : IFlightStatsIntegration
    {
        FlightStatsService service = new FlightStatsService();
        
        public FlightData GetFlightData(string airport, string year, string month, string day, string hour)
        {
            FlightData rs = new FlightData();
            rs.HasError = false;
            rs.Message = string.Empty;
            DateTime value;
            List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            try
            {

                if (numbers.Contains(month))
                {
                    month = "0" + month;
                }

                if (numbers.Contains(day))
                {
                    day = "0" + day;
                }

                if (string.IsNullOrEmpty(airport) || string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month) ||
                    string.IsNullOrEmpty(day) || string.IsNullOrEmpty(hour))
                {
                    rs.HasError = true;
                    rs.Message = "All input data must be sent.";
                }
                else if (!DateTime.TryParseExact($"{day}/{month}/{year} {hour}:00:00,000",
                    "dd/MM/yyyy HH:mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out value))
                {
                    rs.HasError = true;
                    rs.Message = "Invalid date.";
                }
                else
                {
                    rs.Arrival = service.getArrivalsFlightStatus(airport, year, month, day, hour);
                    rs.Departure = service.getDeparturesFlightStatus(airport, year, month, day, hour);
                }
            }
            catch (Exception e)
            {
                rs.HasError = true;
                rs.Message = e.Message;
            }

            return rs;
        }

        public AirlineData GetAirlinesData()
        {
            AirlineData rs = new AirlineData();
            rs.HasError = false;
            rs.Message = string.Empty;
            rs.Airlines = new List<AirlineCustom>();
            
            try
            {
                var arlines = service.getAirlines();

                if (arlines.airlines.Count() > 0)
                {
                    foreach (var item in arlines.airlines)
                    {
                        AirlineCustom a = new AirlineCustom();
                        a.name = item.name;
                        if (string.IsNullOrEmpty(item.iata))
                            a.iata = string.Empty;
                        else
                            a.iata = item.iata;

                        rs.Airlines.Add(a);
                    }
                }
                
            }
            catch (Exception e)
            {
                rs.HasError = true;
                rs.Message = e.Message;
            }

            return rs;
        }

        public AirportData GetAirportsData(string country)
        {
            AirportData rs = new AirportData();
            rs.HasError = false;
            rs.Message = string.Empty;
            rs.Airports = new List<AirportCustom>();

            try
            {
                if (!string.IsNullOrEmpty(country))
                {
                    string code = service.getCodeCountry(country);

                    if (!string.IsNullOrEmpty(code))
                    {
                        var airports = service.getAirports(code);

                        if (airports.airports.Count() > 0)
                        {
                            foreach (var item in airports.airports)
                            {
                                AirportCustom a = new AirportCustom();
                                a.iata = string.IsNullOrEmpty(item.iata) == true ? string.Empty : item.iata;
                                a.name = item.name;
                                a.countryName = item.countryName;
                                a.city = item.city;
                                a.latitude = item.latitude;
                                a.longitude = item.longitude;

                                rs.Airports.Add(a);
                            }
                        }
                    }
                    else
                    {
                        rs.HasError = true;
                        rs.Message = "Country not found.";
                    }
                }
                else
                {
                    rs.HasError = true;
                    rs.Message = "Send a country.";
                }
            }
            catch (Exception e)
            {
                rs.HasError = true;
                rs.Message = e.Message;
            }

            return rs;
        }

    }
}
