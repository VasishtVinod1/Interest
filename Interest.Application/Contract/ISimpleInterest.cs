using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Contract
{
    public interface ISimpleInterest
    {
        double CalculateSimpleInterest(decimal principal, decimal rate, int time);
    }
}
