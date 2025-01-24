using System;

class Airline
{
    // properties
    public string Name { get; set; }
    public string Code { get; set; }
    public Dictonary<string,Flight> Flights { get; set; } = new Dictonary<string, Flight>();

    public Airline() { }
    public Airline(string n, string c, Dictonary<string, Flight> f)
    {
        Name = n;
        Code = c;
        Flights = f;
    }

    // methods
    public bool AddFlight(Flight f)
    {
        if (!Flights.ContainsKey(f.FlightNumber))
        {
            Flights.Add(f.FlightNumber, f);
            return true;
        }
        return false;
    }

    public bool RemoveFlight(Flight f)
    {
        return Flights.Remove(f.FlightNumber);
    }

    public double CalculateFees()
    {
        double fees = 0;
        foreach (Flight flight in Flights.Values)
        {
            fees += flight.CalculateFees();
        }
        return fees;
    }

    public override ToString()
    {
        return "Airline Name: " + Name + "\nAirline Code: " + Code;
    }
}
