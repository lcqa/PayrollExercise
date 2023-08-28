namespace PayrollExercise.Services.Messages.Request.Payroll
{
    public class GetEmployeePayrollRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public double AnnualSalary { get; set; }

        public int SuperRate { get; set; }

        // Month 
        public int PayPeriod { get; set; }
    }
}
