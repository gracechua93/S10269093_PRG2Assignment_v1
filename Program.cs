using S10269093_PRG2Assignment;
using System;
using System.Collections.Generic;
using System.IO;

// Dictionaries
Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGateDict = new Dictionary<string, BoardingGate>();
Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();

// load files
void LoadAirlines(string filePath, Dictionary<string, Airline> airlineDict)
{
    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        string s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string airname = data[0];
            string aircode = data[1];

            // Add to the airline dictionary
            Airline air = new Airline(airname);
            airlineDict[aircode] = airname;
        }
    }
}

foreach (KeyValuePair<string, Airline> pair in airlineDict)
{
    Console.WriteLine($"Code: {pair.Code}, Name: {pair.Name}");
}

void LoadFlights(string filePath, Dictionary<string, Flight> flightDict)
{
    using (StreamReader sr = new StreamReader("flights.csv"))
    {
        string s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string fNum = data[0];
            string fOrigin = data[1];
            string fDest = data[2];
            string eDepart_Arrival = data[3];
        }
    }
}

