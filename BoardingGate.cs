﻿using System;

namespace S10269093_PRG2Assignment
{
    class BoardingGate
    {
        // properties
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; }

        public BoardingGate() { }

        public BoardingGate(string gname, bool sCCFT, bool sDDJB, bool sLWTT)
        {
            GateName = gname;
            SupportsCFFT = sCCFT;
            SupportsDDJB = sDDJB;
            SupportsLWTT = sLWTT;
        }

        public double CalculatFees()
        {
            if (SupportsCFFT)
            {
                return 300 + 150;
            }
            else if (SupportsDDJB)
            {
                return 300 + 300;
            }
            else if (SupportsLWTT)
            {
                return 300 + 500;
            }
            else return 300;
        }

        public override string ToString()
        {
            return "GateName: " + GateName + "\nSupport CTTF: " + SupportsCFFT +
                "\n Support DDJB: " + SupportsDDJB + "\n Support LWTT: " + SupportsLWTT;
        }

    }
}
