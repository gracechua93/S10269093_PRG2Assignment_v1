using S10269093_PRG2Assignment; // Ensure this namespace is valid and referenced
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Airline> airlineDict = new Dictionary<string, Airline>();
        Dictionary<string, BoardingGate> boardingGateDict = new Dictionary<string, BoardingGate>();
        Dictionary<string, Flight> flightDict = new Dictionary<string, Flight>();

        LoadFlights(flightDict, airlineDict);
        LoadBoardingGates(boardingGateDict);

        while (true)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine("Welcome to Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. List All Flights");
            Console.WriteLine("2. List Boarding Gates");
            Console.WriteLine("3. Assign a Boarding Gate to a Flight");
            Console.WriteLine("4. Create Flight");
            Console.WriteLine("5. Display Airline Flights");
            Console.WriteLine("6. Modify Flight Details");
            Console.WriteLine("7. Display Flight Schedule");
            Console.WriteLine("0. Exit");
            Console.Write("\nPlease select your option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ListAllFlights(flightDict, airlineDict);
                    break;
                case "2":
                    ListBoardingGates(boardingGateDict);
                    break;
                case "3":
                    AssignBoardingGate(flightDict, boardingGateDict);
                    break;
                case "4":
                    CreateFlight(flightDict);
                    break;
                case "5":
                    DisplayAirlineFlights(flightDict, airlineDict);
                    break;
                case "6":
                    ModifyFlightDetails(flightDict);
                    break;
                case "7":
                    DisplayFlightSchedule(flightDict);
                    break;
                case "0":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void LoadFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
{
    // Example data loading (you can replace this with file reading or database retrieval logic)
    airlineDict["SQ"] = new Airline("SQ", "Singapore Airlines");
    flightDict["SQ001"] = new Flight("SQ001", "Singapore", "Tokyo", DateTime.Parse("01/02/2025 12:00"));
    flightDict["SQ002"] = new Flight("SQ002", "Singapore", "New York", DateTime.Parse("01/02/2025 18:00"));
}

static void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGateDict)
{
    // Example data loading
    boardingGateDict["A1"] = new BoardingGate("A1", true, true, false);
    boardingGateDict["B1"] = new BoardingGate("B1", false, true, true);
}


    // Functions for menu options
    static void ListAllFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine("List of Flights for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        Console.WriteLine("Flight Number   Airline Name        Origin               Destination        Expected Time");
        foreach (var flight in flightDict.Values)
        {
            string airlineName = airlineDict.ContainsKey(flight.FlightNumber) ? airlineDict[flight.FlightNumber].Name : "Unknown Airline";
            Console.WriteLine($"{flight.FlightNumber,-15} {airlineName,-20} {flight.Origin,-20} {flight.Destination,-20} {flight.ExpectedTime}");
        }
    }

    static void ListBoardingGates(Dictionary<string, BoardingGate> boardingGateDict)
    {
        Console.WriteLine("\n=============================================");
        Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
        Console.WriteLine("=============================================");
        Console.WriteLine("Gate Name       DDJB    CFFT    LWTT");
        foreach (var gate in boardingGateDict.Values)
        {
            Console.WriteLine($"{gate.GateName,-15} {gate.SupportsDDJB,-8} {gate.SupportsCFFT,-8} {gate.SupportsLWTT}");
        }
    }

    static void AssignBoardingGate(Dictionary<string, Flight> flightDict, Dictionary<string, BoardingGate> boardingGateDict)
    {
        Console.Write("Enter Flight Number: ");
        string flightNum = Console.ReadLine();
        if (!flightDict.ContainsKey(flightNum))
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter Boarding Gate Name: ");
        string gateName = Console.ReadLine();
        if (!boardingGateDict.ContainsKey(gateName))
        {
            Console.WriteLine("Boarding gate not found.");
            return;
        }

        flightDict[flightNum].BoardingGate = boardingGateDict[gateName];
        Console.WriteLine($"Flight {flightNum} has been assigned to Boarding Gate {gateName}!");
    }

    static void CreateFlight(Dictionary<string, Flight> flightDict)
    {
        Console.Write("Enter Flight Number: ");
        string flightNum = Console.ReadLine();
        Console.Write("Enter Origin: ");
        string origin = Console.ReadLine();
        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();
        Console.Write("Enter Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
        DateTime expectedTime = DateTime.Parse(Console.ReadLine());

        Flight newFlight = new Flight(flightNum, origin, destination, expectedTime);
        flightDict[flightNum] = newFlight;
        Console.WriteLine($"Flight {flightNum} has been added!");
    }

    static void DisplayAirlineFlights(Dictionary<string, Flight> flightDict, Dictionary<string, Airline> airlineDict)
    {
        Console.Write("Enter Airline Code: ");
        string airlineCode = Console.ReadLine();
        if (!airlineDict.ContainsKey(airlineCode))
        {
            Console.WriteLine("Airline not found.");
            return;
        }

        Console.WriteLine($"Flights operated by {airlineDict[airlineCode].Name}:");
        foreach (var flight in flightDict.Values)
        {
            if (flight.FlightNumber.StartsWith(airlineCode))
            {
                Console.WriteLine($"{flight.FlightNumber} - {flight.Origin} to {flight.Destination} at {flight.ExpectedTime}");
            }
        }
    }

    static void ModifyFlightDetails(Dictionary<string, Flight> flightDict)
    {
        Console.Write("Enter Flight Number to Modify: ");
        string flightNum = Console.ReadLine();
        if (!flightDict.ContainsKey(flightNum))
        {
            Console.WriteLine("Flight not found.");
            return;
        }

        Console.Write("Enter New Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
        flightDict[flightNum].ExpectedTime = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Flight details updated!");
    }

    static void DisplayFlightSchedule(Dictionary<string, Flight> flightDict)
    {
        Console.WriteLine("\nFlight Schedule:");
        foreach (var flight in flightDict.Values)
        {
            Console.WriteLine($"{flight.FlightNumber} - {flight.ExpectedTime}");
        }
    }
}
