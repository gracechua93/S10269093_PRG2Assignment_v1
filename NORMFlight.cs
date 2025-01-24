using System;

class NORMFlight : Flight
{
    public NORMFlight(string fN, string o, string d, datetime et, string s) : base(fN, o, d, et, s) { }

    public override double CalculateFees()
    {
        if (Origin == "SIN")
        {
            return 500 + 300;
        }
        else if (Destination == "SIN" )
        {
            return 800 + 300;
        }
    }

    public override string ToString()
    {
        return base.ToString() + "Normal Flight";
    }
}
