﻿using S10269093_PRG2Assignment;
using System;
using System.Collections.Generic;
using System.IO;

// Dictionaries
Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGateDict = new Dictionary<string, BoardingGate>();
Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();

// load files
LoadFlights(flightDict);

void LoadFlights(Dictionary<string, Flight> flightDict)
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
            DateTime eDepart_Arrival = DateTime.Parse(data[3]);

            // Add to the flight dictionary
            Flight flight = new Flight(fNum, fOrigin, fDest, eDepart_Arrival);
            flightDict[fNum] = flight;
        }
    }


    using (StreamReader sr = new StreamReader("airlines.csv"))
    {
        string s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string airname = data[0];
            string aircode = data[1];

            // Add to the airline dictionary
            Airline airline = new Airline(aircode, airname);
            airlineDict[aircode] = airline;
        }
    }
    Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
                "Flight Number", "Airline Number", "Origin", "Destination", "Expected Departure/Arrival Time");
    foreach (KeyValuePair<string, Airline> a in airlineDict)
    {

        foreach (KeyValuePair<string, Flight> f in flightDict)
        {

            Console.WriteLine("{0,-15} {1,-20} {2,-23} {3,-20} {4,-15}",
                f.Value.FlightNumber, a.Value.Name, f.Value.Origin, f.Value.Destination, f.Value.ExpectedTime);
        }
    }
}

LoadBoardingGates(boardingGateDict);
void LoadBoardingGates(Dictionary<string, BoardingGate> bgDict)
{
    using (StreamReader sr = new StreamReader("boardinggates.csv"))
    {
        string s = sr.ReadLine();

        while ((s = sr.ReadLine()) != null)
        {
            string[] data = s.Split(',');
            string bGate = data[0];
            bool isDDJB = bool.Parse(data[1]);
            bool isCFFT = bool.Parse(data[2]);
            bool isLWTT = bool.Parse(data[3]);

            // Add to the flight dictionary
            BoardingGate boardingGate = new BoardingGate(bGate, isDDJB, isCFFT, isLWTT);
            bgDict[bGate] = boardingGate;
        }
    }
    Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
            "Gate Number", "DDJB", "CFFT", "LWTT");
    foreach (KeyValuePair<string, BoardingGate> bg in bgDict)
    {
        Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-20}",
            bg.Value.GateName, bg.Value.SupportsDDJB, bg.Value.SupportsCFFT, bg.Value.SupportsLWTT);
    }
}

