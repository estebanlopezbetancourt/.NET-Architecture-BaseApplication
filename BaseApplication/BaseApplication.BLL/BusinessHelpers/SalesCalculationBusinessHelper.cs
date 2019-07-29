using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.BLL.BusinessHelpers
{
    internal static class SalesCalculationBusinessHelper
    {
        internal static double GetIVA(double amount)
        {
            return amount * 0.18;
        }
    }
}
