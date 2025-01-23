using System;

public class LWTTFlight : Flight
{
    public double RequestFee { get; set; }

    public LWTTFlight() : base() { }

    public LWTTFlight(string fN, string o, string d, datetime et, string s, double rF) : base()
    {
        RequestFee = rF;
    }

    public override double CalculateFees()
    {

    }

    public override string ToString()
    {

    }
}
