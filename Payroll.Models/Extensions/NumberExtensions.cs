using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Models.Extensions
{
    public static class NumberExtensions
    {
        public static double ToTwoDecimalPlaces(this double value)
        {
            return Math.Round(value, 2);
        }
    }
}
