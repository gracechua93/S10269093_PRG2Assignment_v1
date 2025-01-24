using System;

namespace S10269093_PRG2Assignment
{
    class NORMFlight : Flight
    {
        public NORMFlight(string fN, string o, string d, DateTime et, string s) : base(fN, o, d, et, s) { }

        public override double CalculateFees()
        {
            if (Origin == "SIN")
            {
                return 500 + 300;
            }
            else if (Destination == "SIN")
            {
                return 800 + 300;
            }

            return 0;
        }

        public override string ToString()
        {
            return base.ToString() + "Normal Flight";
        }
    }
}
