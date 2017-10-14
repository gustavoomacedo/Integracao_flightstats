using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFlightStats.ServiceFlightStats;

namespace ConsoleFlightStats
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("::::::::::::::: INTEGRAÇÃO FLIGHT STATS :::::::::::::::::::::::::");

                Console.WriteLine("Escolha a opção para busca dos dados:\n");
                Console.WriteLine("1 - Dados das 5 primeiras partidas e chegadas de voos dado um código iata de aeroporto, dia, mês, ano, hora (e no período de uma hora).\n");
                Console.WriteLine("2 - O nome e iata de todas companhias aéreas.\n");
                Console.WriteLine("3 - O  nome, iata, pais, cidade, latitude e longitude dos aeroportos dado um país. \n");
                Console.WriteLine("0 - Sair. \n");
                opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Voos();
                        break;
                    case 2:
                        Companhias();
                        break;
                    case 3:
                        Aeroportos();
                        break;
                    case 0:
                        Console.WriteLine("Voce saiu.");
                        break;
                    default:
                        Console.WriteLine("Opção errada.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
        }

        private static void Voos()
        {
            Console.WriteLine("Digite o código iata de aeroporto:");
            string iata = Console.ReadLine();
            Console.WriteLine("Digite o dia:");
            string dia = Console.ReadLine();
            Console.WriteLine("Digite o mes:");
            string mes = Console.ReadLine();
            Console.WriteLine("Digite o ano:");
            string ano = Console.ReadLine();
            Console.WriteLine("Digite a hora:");
            string hora = Console.ReadLine();

            FlightStatsIntegrationClient client = new FlightStatsIntegrationClient();
            FlightData voos = client.GetFlightData(iata, ano, mes, dia, hora);

            if (voos.HasError)
            {
                Console.WriteLine("Ocorreu um erro: "+ voos.Message);
            }
            else
            {
                if (voos.Arrival != null)
                {
                    foreach (var item in voos.Arrival.flightStatuses)
                    {
                        Console.WriteLine("::::::::::: CHEGADA :::::::::::::::");
                        Console.WriteLine("flightId " + item.flightId);
                        Console.WriteLine("carrierFsCode " + item.carrierFsCode);
                        Console.WriteLine("flightNumber " + item.flightNumber);
                        Console.WriteLine("departureAirportFsCode " + item.departureAirportFsCode);
                        Console.WriteLine("arrivalAirportFsCode " + item.arrivalAirportFsCode);
                        Console.WriteLine("status " + item.status);
                        Console.WriteLine("departureDate dateLocal " + item.departureDate.dateLocal.ToString());
                        Console.WriteLine("departureDate dateUtc " + item.departureDate.dateUtc.ToString());
                        Console.WriteLine("arrivalDate dateLocal " + item.arrivalDate.dateLocal.ToString());
                        Console.WriteLine("arrivalDate dateUtc " + item.arrivalDate.dateUtc.ToString());
                        Console.WriteLine("schedule flightType " + item.schedule.flightType);
                        Console.WriteLine("schedule serviceClasses " + item.schedule.serviceClasses);
                        Console.WriteLine("schedule restrictions " + item.schedule.restrictions);
                        Console.WriteLine("operationalTimes publishedDeparture dateLocal " + item.operationalTimes.publishedDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedDeparture dateLocal " + item.operationalTimes.publishedDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedArrival dateLocal " + item.operationalTimes.publishedArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedArrival dateLocal " + item.operationalTimes.publishedArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateDeparture dateLocal " + item.operationalTimes.scheduledGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateDeparture dateLocal " + item.operationalTimes.scheduledGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateDeparture dateLocal " + item.operationalTimes.estimatedGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateDeparture dateLocal " + item.operationalTimes.estimatedGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateDeparture dateLocal " + item.operationalTimes.actualGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateDeparture dateLocal " + item.operationalTimes.actualGateDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayDeparture dateLocal " + item.operationalTimes.estimatedRunwayDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayDeparture dateLocal " + item.operationalTimes.estimatedRunwayDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayDeparture dateLocal " + item.operationalTimes.actualRunwayDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayDeparture dateLocal " + item.operationalTimes.actualRunwayDeparture.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateArrival dateLocal " + item.operationalTimes.scheduledGateArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateArrival dateLocal " + item.operationalTimes.scheduledGateArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateArrival dateLocal " + item.operationalTimes.estimatedGateArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateArrival dateLocal " + item.operationalTimes.estimatedGateArrival.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateArrival dateLocal " + item.operationalTimes?.actualGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateArrival dateLocal " + item.operationalTimes?.actualGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayArrival dateLocal " + item.operationalTimes?.estimatedRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayArrival dateLocal " + item.operationalTimes?.estimatedRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayArrival dateLocal " + item.operationalTimes?.actualRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayArrival dateLocal " + item.operationalTimes?.actualRunwayArrival?.dateLocal.ToString());

                        if (item.codeshares != null)
                        {
                            foreach (var code in item.codeshares)
                            {
                                Console.WriteLine("codeshares fsCode " + code?.fsCode);
                                Console.WriteLine("codeshares flightNumber " + code?.flightNumber);
                                Console.WriteLine("codeshares relationship " + code?.relationship);
                            }
                        }

                        Console.WriteLine("delays arrivalGateDelayMinutes " + item.delays?.arrivalGateDelayMinutes.ToString());
                        Console.WriteLine("delays departureGateDelayMinutes " + item.delays?.departureGateDelayMinutes.ToString());

                        Console.WriteLine("flightDurations scheduledBlockMinutes " + item.flightDurations?.scheduledBlockMinutes.ToString());
                        Console.WriteLine("flightDurations blockMinutes " + item.flightDurations?.blockMinutes.ToString());
                        Console.WriteLine("flightDurations airMinutes " + item.flightDurations?.airMinutes.ToString());
                        Console.WriteLine("flightDurations taxiOutMinutes " + item.flightDurations?.taxiOutMinutes.ToString());
                        Console.WriteLine("flightDurations taxiInMinutes " + item.flightDurations?.taxiInMinutes.ToString());

                        Console.WriteLine("airportResources departureTerminal " + item.airportResources?.departureTerminal);
                        Console.WriteLine("airportResources departureGate " + item.airportResources?.departureGate);
                        Console.WriteLine("airportResources arrivalTerminal " + item.airportResources?.arrivalTerminal);

                        Console.WriteLine("flightEquipment scheduledEquipmentIataCode " + item.flightEquipment?.scheduledEquipmentIataCode);
                        Console.WriteLine("flightEquipment actualEquipmentIataCode " + item.flightEquipment?.actualEquipmentIataCode);
                        Console.WriteLine("flightEquipment tailNumber " + item.flightEquipment?.tailNumber);

                        Console.WriteLine("::::::::::::::::::::::::::::::::::::\n");
                    }
                }
                else
                {
                    Console.WriteLine("NENHUMA CHEGADA REGISTRADA \n");
                }

                if (voos.Departure != null)
                {
                    foreach (var item in voos.Departure.flightStatuses)
                    {
                        Console.WriteLine("::::::::::: SAIDA :::::::::::::::");
                        Console.WriteLine("flightId " + item.flightId);
                        Console.WriteLine("carrierFsCode " + item.carrierFsCode);
                        Console.WriteLine("flightNumber " + item.flightNumber);
                        Console.WriteLine("departureAirportFsCode " + item?.departureAirportFsCode);
                        Console.WriteLine("arrivalAirportFsCode " + item.arrivalAirportFsCode);
                        Console.WriteLine("status " + item.status);
                        Console.WriteLine("departureDate dateLocal " + item?.departureDate?.dateLocal.ToString());
                        Console.WriteLine("departureDate dateUtc " + item?.departureDate?.dateUtc.ToString());
                        Console.WriteLine("arrivalDate dateLocal " + item.arrivalDate?.dateLocal.ToString());
                        Console.WriteLine("arrivalDate dateUtc " + item.arrivalDate?.dateUtc.ToString());
                        Console.WriteLine("schedule flightType " + item.schedule.flightType);
                        Console.WriteLine("schedule serviceClasses " + item.schedule.serviceClasses);
                        Console.WriteLine("schedule restrictions " + item.schedule.restrictions);
                        Console.WriteLine("operationalTimes publishedDeparture dateLocal " + item.operationalTimes.publishedDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedDeparture dateLocal " + item.operationalTimes.publishedDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedArrival dateLocal " + item.operationalTimes.publishedArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes publishedArrival dateLocal " + item.operationalTimes.publishedArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateDeparture dateLocal " + item.operationalTimes.scheduledGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateDeparture dateLocal " + item.operationalTimes.scheduledGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateDeparture dateLocal " + item.operationalTimes.estimatedGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateDeparture dateLocal " + item.operationalTimes.estimatedGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateDeparture dateLocal " + item.operationalTimes?.actualGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateDeparture dateLocal " + item.operationalTimes?.actualGateDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayDeparture dateLocal " + item.operationalTimes?.estimatedRunwayDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayDeparture dateLocal " + item.operationalTimes?.estimatedRunwayDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayDeparture dateLocal " + item.operationalTimes?.actualRunwayDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayDeparture dateLocal " + item.operationalTimes?.actualRunwayDeparture?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateArrival dateLocal " + item.operationalTimes?.scheduledGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes scheduledGateArrival dateLocal " + item.operationalTimes?.scheduledGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateArrival dateLocal " + item.operationalTimes.estimatedGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedGateArrival dateLocal " + item.operationalTimes.estimatedGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateArrival dateLocal " + item.operationalTimes?.actualGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualGateArrival dateLocal " + item.operationalTimes?.actualGateArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayArrival dateLocal " + item.operationalTimes?.estimatedRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes estimatedRunwayArrival dateLocal " + item.operationalTimes?.estimatedRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayArrival dateLocal " + item.operationalTimes?.actualRunwayArrival?.dateLocal.ToString());
                        Console.WriteLine("operationalTimes actualRunwayArrival dateLocal " + item.operationalTimes?.actualRunwayArrival?.dateLocal.ToString());

                        if (item.codeshares != null)
                        {
                            foreach (var code in item.codeshares)
                            {
                                Console.WriteLine("codeshares fsCode " + code?.fsCode);
                                Console.WriteLine("codeshares flightNumber " + code?.flightNumber);
                                Console.WriteLine("codeshares relationship " + code?.relationship);
                            }
                        }

                        Console.WriteLine("delays arrivalGateDelayMinutes " + item.delays?.arrivalGateDelayMinutes.ToString());
                        Console.WriteLine("delays departureGateDelayMinutes " + item.delays?.departureGateDelayMinutes.ToString());

                        Console.WriteLine("flightDurations scheduledBlockMinutes " + item.flightDurations?.scheduledBlockMinutes.ToString());
                        Console.WriteLine("flightDurations blockMinutes " + item.flightDurations?.blockMinutes.ToString());
                        Console.WriteLine("flightDurations airMinutes " + item.flightDurations?.airMinutes.ToString());
                        Console.WriteLine("flightDurations taxiOutMinutes " + item.flightDurations?.taxiOutMinutes.ToString());
                        Console.WriteLine("flightDurations taxiInMinutes " + item.flightDurations?.taxiInMinutes.ToString());

                        Console.WriteLine("airportResources departureTerminal " + item.airportResources?.departureTerminal);
                        Console.WriteLine("airportResources departureGate " + item.airportResources?.departureGate);
                        Console.WriteLine("airportResources arrivalTerminal " + item.airportResources?.arrivalTerminal);

                        Console.WriteLine("flightEquipment scheduledEquipmentIataCode " + item.flightEquipment?.scheduledEquipmentIataCode);
                        Console.WriteLine("flightEquipment actualEquipmentIataCode " + item.flightEquipment?.actualEquipmentIataCode);
                        Console.WriteLine("flightEquipment tailNumber " + item.flightEquipment?.tailNumber);

                        Console.WriteLine("::::::::::::::::::::::::::::::::::::\n");
                    }
                }
                else
                {
                    Console.WriteLine("NENHUMA SAIDA REGISTRADA \n");
                }

                
            }

            client.Close();
        }
        
        private static void Companhias()
        {
            FlightStatsIntegrationClient client = new FlightStatsIntegrationClient();
            AirlineData airline = client.GetAirlinesData();

            if (airline.HasError)
            {
                Console.WriteLine("Ocorreu um erro: " + airline.Message);
            }
            else
            {
                foreach (var item in airline.Airlines)
                {
                    Console.WriteLine("Iata: " + item?.iata + ", Name: " + item?.name);
                }
            }

            client.Close();
        }

        private static void Aeroportos()
        {
            Console.WriteLine("Digite o nome do pais (em ingles) :\n");
            string pais = Console.ReadLine();

            FlightStatsIntegrationClient client = new FlightStatsIntegrationClient();
            AirportData airport = client.GetAirportsData(pais);

            if (airport.HasError)
            {
                Console.WriteLine("Ocorreu um erro: " + airport.Message);
            }
            else
            {
                foreach (var item in airport.Airports)
                {
                    Console.WriteLine("::::::::::::::::::::::::::"+
                        "\n Nome: " + item?.name +
                        "\n Iata: " + item?.iata +
                        "\n Pais: " + item?.countryName +
                        "\n Cidade: " + item?.city +
                        "\n Latitude: " + item?.latitude.ToString("N2") +
                        "\n Longitude: " + item?.longitude.ToString("N2"));
                }
            }

            client.Close();
        }

    }
}
