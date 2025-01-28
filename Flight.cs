using System;

namespace S10269093_PRG2Assignment
{
    class Flight
    {
        // Properties
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; } // Add the Status property

        // Constructors
        public Flight() { }

        public Flight(string flightNumber, string origin, string destination, DateTime expectedTime)
        {
            FlightNumber = flightNumber;
            Origin = origin;
            Destination = destination;
            ExpectedTime = expectedTime;
        }

        // Methods
        public virtual double CalculateFees()
        {
            return 0;
        }

        public override string ToString()
        {
            return "Flight Number: " + FlightNumber +
                   "\nOrigin: " + Origin +
                   "\nDestination: " + Destination +
                   "\nExpected Time: " + ExpectedTime +
                   "\nStatus: " + Status;
        }
    }
}
