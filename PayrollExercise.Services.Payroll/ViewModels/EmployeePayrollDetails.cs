﻿namespace PayrollExercise.Services.ViewModels
{
    public class EmployeePayrollDetails
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PayPeriod { get; set; }

        public double GrossIncome { get; set; }

        public double NetIncome { get; set; }

        public double IncomeTax { get; set; }

        public double Super { get; set; }
    }
}
