using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Infrastructure.Exceptions
{
    public class PayrollServiceException : Exception
    {
        public PayrollServiceException(string message) : base(message)
        {

        }

        public PayrollServiceException(string message, Exception innerException) : base(message,innerException)
        {

        }
    }
}
