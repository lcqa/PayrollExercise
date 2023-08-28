using PayrollExercise.Models.Models.Payroll;
using PayrollExercise.Services.ViewModels;

namespace PayrollExercise.Services.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeePayrollDetails ToEmployeePayrollDetails(this Employee employee)
        {
            return new EmployeePayrollDetails()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                GrossIncome = employee.PayrollDetails.GrossIncome,
                NetIncome = employee.PayrollDetails.NetIncome,
                PayPeriod = employee.PayrollDetails.PayPeriod,
                IncomeTax = employee.PayrollDetails.IncomeTax,
                Super = employee.PayrollDetails.Super,
            };
        }
    }
}
