using S10269093_PRG2Assignment; // Ensure this namespace is valid and referenced
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Dictionaries
        Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
        Dictionary<string, BoardingGate> boardingGateDict = new Dictionary<string, BoardingGate>();
        Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();

        // Load files
        LoadFlights(flightDict, airlineDict);
        LoadBoardingGates(boardingGateDict);
    }

    static void LoadFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
    {
        // Load Flights from CSV
        using (StreamReader sr = new StreamReader("flights.csv"))
        {
            string s = sr.ReadLine(); // Skip the header

            while ((s = sr.ReadLine()) != null)
            {
                string[] data = s.Split(',');
                string fNum = data[0];
                string fOrigin = data[1];
                string fDest = data[2];
                DateTime eDepart_Arrival = DateTime.Parse(data[3]);

                // Add to the flight dictionary
                Flight flight = new Flight(fNum, fOrigin, fDest, eDepart_Arrival);
                flightDict[fNum] = flight;
            }
        }

        // Load Airlines from CSV
        using (StreamReader sr = new StreamReader("airlines.csv"))
        {
            string s = sr.ReadLine(); // Skip the header

            while ((s = sr.ReadLine()) != null)
            {
                string[] data = s.Split(',');
                string airName = data[0];
                string airCode = data[1];

                // Add to the airline dictionary
                Airline airline = new Airline(airCode, airName);
                airlineDict[airCode] = airline;
            }
        }

        // Display Flights
        Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
            "Flight Number", "Airline Number", "Origin", "Destination", "Expected Departure/Arrival Time");

        foreach (var flightEntry in flightDict)
        {
            Flight flight = flightEntry.Value;
            string airlineName = airlineDict.ContainsKey(flight.FlightNumber) ? airlineDict[flight.FlightNumber].Name : "Unknown Airline";

            Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
                flight.FlightNumber, airlineName, flight.Origin, flight.Destination, flight.ExpectedTime);
        }
    }

    static void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGateDict)
    {
        using (StreamReader sr = new StreamReader("boardinggates.csv"))
        {
            string s = sr.ReadLine(); // Skip the header

            while ((s = sr.ReadLine()) != null)
            {
                string[] data = s.Split(',');
                string gateName = data[0];
                bool isDDJB = bool.Parse(data[1]);
                bool isCFFT = bool.Parse(data[2]);
                bool isLWTT = bool.Parse(data[3]);

                // Add to the boarding gate dictionary
                BoardingGate boardingGate = new BoardingGate(gateName, isDDJB, isCFFT, isLWTT);
                boardingGateDict[gateName] = boardingGate;
            }
        }

        // Display Boarding Gates
        Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
            "Gate Number", "DDJB", "CFFT", "LWTT");

        foreach (var gateEntry in boardingGateDict)
        {
            BoardingGate gate = gateEntry.Value;
            Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
                gate.GateName, gate.SupportsDDJB, gate.SupportsCFFT, gate.SupportsLWTT);
        }
    }
}
