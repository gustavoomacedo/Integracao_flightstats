using Integracao_flightstats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Integracao_flightstats.Services
{
    public class FlightStatsService
    {
        private const string BaseUrl = "https://api.flightstats.com/flex/";
        private const string appId = "SEU APPID";
        private const string appKey = "SUA APPKEY";
        HttpClient client = new HttpClient();
        
        public Arrival getArrivalsFlightStatus(string airport, string year, string month, string day, string hour)
        {
            Arrival data = new Arrival();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.
                GetAsync($"{BaseUrl}flightstatus/rest/v2/json/airport/status/{airport}/arr/{year}/{month}/{day}/{hour}?appId={appId}&appKey={appKey}&utc=false&numHours=1&maxFlights=5").Result;

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = response.Content.ReadAsStreamAsync())
                {
                    data = JsonConvert.DeserializeObject<Arrival>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return data;
        }

        public Departure getDeparturesFlightStatus(string airport, string year, string month, string day, string hour)
        {
            Departure data = new Departure();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.
                GetAsync($"{BaseUrl}flightstatus/rest/v2/json/airport/status/{airport}/dep/{year}/{month}/{day}/{hour}?appId={appId}&appKey={appKey}&utc=false&numHours=1&maxFlights=5").Result;

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = response.Content.ReadAsStreamAsync())
                {
                    data = JsonConvert.DeserializeObject<Departure>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return data;
        }
        
        public Airlines getAirlines()
        {
            Airlines arlines = new Airlines();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.
                GetAsync($"{BaseUrl}airlines/rest/v1/json/all?appId={appId}&appKey={appKey}").Result;

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = response.Content.ReadAsStreamAsync())
                {
                   return arlines = JsonConvert.DeserializeObject<Airlines>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return arlines;
        }

        public string getCodeCountry(string country)
        {
            var serverPath = System.Web.Hosting.HostingEnvironment.MapPath("~/countries.json");
            using (StreamReader r = new StreamReader(serverPath))
            {
                string json = r.ReadToEnd();
                List<Country> items = JsonConvert.DeserializeObject<List<Country>>(json);
                var _country = items.Where(x => x.name.ToLower().Equals(country.ToLower())).FirstOrDefault();

                if (_country != null)
                    return _country.code;
                else
                    return string.Empty;
            }
        }

        public Airports getAirports(string code)
        {
            Airports airports = new Airports();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.
                GetAsync($"{BaseUrl}airports/rest/v1/json/countryCode/{code}?appId={appId}&appKey={appKey}").Result;

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = response.Content.ReadAsStreamAsync())
                {
                    return airports = JsonConvert.DeserializeObject<Airports>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return airports;
        }
        
    }
}