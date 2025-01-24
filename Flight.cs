using System;

namespace S10269093_PRG2Assignment
{
    abstract class Flight
    {
        // properties
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }

        // constructors
        public Flight() { }

        public Flight(string fN, string o, string d, DateTime et, string s)
        {
            FlightNumber = fN;
            Origin = o;
            Destination = d;
            ExpectedTime = et;
            Status = s;
        }

        public abstract double CalculateFees();

        public override string ToString()
        {
            return "Flight Number: " + FlightNumber +
                "\nOrigin: " + Origin + "\nDestination: " +
                Destination + "\nExpected Time: " + ExpectedTime + "\nStatus: " + Status;
        }

    }
}
