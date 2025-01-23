using System;

public class DDJBFlight : Flight
{
    public double RequestFee { get; set; }

    public DDJBFlight() : base() { }

    public DDJBFlight(string fN, string o, string d, datetime et, string s, double rF) : base()
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
