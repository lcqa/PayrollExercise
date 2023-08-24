using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Models.Models.Payroll
{
    public class Employee
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public PayrollDetails PayrollDetails { get; private set; }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Employee(string firstName, string lastName, PayrollDetails payrollDetails)
        {
            FirstName = firstName;
            LastName = lastName;
            PayrollDetails = payrollDetails;
        }

        public void ComputePayrollDetails(double annualSalary, int superRate, int month)
        {
            PayrollDetails = new PayrollDetails(annualSalary, superRate, month);
        }
    }
}
