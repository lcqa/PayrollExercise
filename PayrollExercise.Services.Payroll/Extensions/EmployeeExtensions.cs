using PayrollExercise.Models.Models.Payroll;
using PayrollExercise.Services.Payroll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Extensions
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
