namespace PayrollExercise.Services.Exceptions
{
    public class PayrollServiceException : Exception
    {
        public PayrollServiceException(string message) : base(message)
        {

        }

        public PayrollServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
