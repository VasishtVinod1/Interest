using Interest.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Services
{
    public class SimpleInterest : ISimpleInterest
    {
        public double CalculateSimpleInterest(int principal, int rate, int time)
        {
            if (principal <= 0 || rate < 0 || time <= 0)
            {
                throw new ArgumentException("Principal, rate, and time must be greater than zero.");
            }
            // Convert rate from percentage to decimal
            double rateDecimal = (double)rate / 100;
            // Calculate simple interest using the formula SI = P * r * t
            double simpleInterest = (double)principal * rateDecimal * time;
            return simpleInterest;
        }
    }
}
