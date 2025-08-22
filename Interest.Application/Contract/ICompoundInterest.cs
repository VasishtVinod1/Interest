using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Application.Contract
{
    public interface ICompoundInterest
    {
        double CalculateCompoundInterest(int principal, int rate, int time, int frequency);
    }
}
