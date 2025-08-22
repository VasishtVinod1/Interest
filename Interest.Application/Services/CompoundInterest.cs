using Interest.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Services
{
    public class CompoundInterest : ICompoundInterest
    {
        public double CalculateCompoundInterest(int principal, int rate, int time, int frequency)
        {
            if (principal <= 0 || rate < 0 || time <= 0 || frequency <= 0)
            {
                throw new ArgumentException("Principal, rate, time, and frequency must be greater than zero.");
            }
            // Convert rate from percentage to decimal
            double rateDecimal = (double)rate / 100;
            // Calculate compound interest using the formula A = P(1 + r/n)^(nt)
            double amount = (double)principal * Math.Pow((1 + rateDecimal / frequency), frequency * time);
            double compoundInterest = amount - (double)principal;
            return compoundInterest;
        }
    }
}
