using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.Utils
{
    public static class DbCalc
    {
        public static double calculateDecibels(double ampValue)
        {
            if (ampValue == 0)
            {
                return 0.0;
            }
            return 20 * Math.Log10(ampValue);
        }
    }
}
