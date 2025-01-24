using System;

class Terminal
{
    public string TerminalName { get; set; }
    public Dictonary<string, Airline> Airlines { get; set; } = new Dictonary<string, Airline>();
    public Dictonary<string, Flight> Flights { get; set; } = new Dictonary<string, Flight>();
    public Dictonary<string, BoardingGate> BoardingGate { get; set; } = new Dictonary<string, BoardingGate>();\
    public Dictonary<string, double> GateFees { get; set; } = new Dictonary<string, double>();
    
    public Terminal() { }

    public Terminal(string t, Dictonary<string, Airline> a, Dictonary<string, Flight> f, Dictonary<string, BoardingGate> bg, Dictonary<string, double> gf)
    {
        TerminalName = t;
        Airlines = a;
        Flights = f;
        BoardingGate = bg;
        GateFees = gf;
    }

    // methods
    public bool AddAirline(Airline a)
    {
        if (!Airlines.ContainsKey(a.Code))
        {
            Airlines[a.Code] = a;
            return true;
        }
        return false;
    }

    public bool AddBoardingGate(BoardingGate gate) 
    {
        if (!BoardingGates.ContainsKey(gate.GateName))
        {
            BoardingGates[gate.GateName] = gate;
            return true;
        }
        return false;
    }

    public Airline GetAirlineFromFlight(Flight f) 
    {
        foreach (Airline a in Airlines.Values)
        {
            if (a.Flights.ContainsKey(f.FlightNumber))
            {
                return a;
            }
        }
        Console.Writeline("Unable to find such airline.");
    }

    public void PrintAirlineFees()
    {
        foreach (Airline a in Airlines.Values)
        {
            Console.WriteLine($"Airline: {a.Name}, Fees: {a.CalculateFees()}");
        }
    }

    public override ToString()
    {
        return "Terminal: " + TerminalName;
    }
}
