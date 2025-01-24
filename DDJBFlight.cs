using System;

public class DDJBFlight : Flight
{
    public double RequestFee { get; set; }

    public DDJBFlight() : base() { }

    public DDJBFlight(string fN, string o, string d, datetime et, string s, double rF) : base(fN, o, d, et)
    {
        RequestFee = rF;
    }

    public override double CalculateFees()
    {
        double fees = 0;
        if (Origin == "SIN")
        {
            fees = 500 + 300;
        }
        else if (Destination == "SIN")
        {
            fees = 800 + 300;
        }

        RequestFee = 300;
        fees += RequestFee;
        return fees;

    }

    public override string ToString()
    {
        return base.ToString() + "DDJB Flight";
    }
}
