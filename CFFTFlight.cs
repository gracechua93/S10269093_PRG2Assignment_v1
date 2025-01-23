using System;

class CFFTFlight : Flight
{
    public double RequestFee { get; set; }

    public CFFTFlight() : base() { }
    public CFFTFlight(string fN, string o, string d, datetime et, string s, double rF) :base(fN, o, d, et ,s)
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
