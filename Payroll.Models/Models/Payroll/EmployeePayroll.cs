using PayrollExercise.Models.Extensions;

namespace PayrollExercise.Models.Models.Payroll
{
    public class EmployeePayroll
    {
        public Employee Employee { get; set; }

        //Month
        public string PayPeriod { get; set; } = string.Empty;

        public double GrossIncome { get; private set; }

        public double IncomeTax { get; private set; }

        public double NetIncome { get; private set; }

        public double Super { get; private set; }

        public EmployeePayroll()
        {

        }

        public EmployeePayroll(Employee employee, double annualSalary, int superRate)
        {
            this.Employee = employee;
            ComputeGrossIncome(annualSalary);
            ComputeIncomeTax(annualSalary);
            ComputeNetIncome();
            ComputeSuper(superRate);
        }

        private void ParsePayPeriod()
        {
            this.PayPeriod = $"01 ";
        }

        private void ComputeGrossIncome(double annualSalary)
        {
            this.GrossIncome = (annualSalary / 12).ToTwoDecimalPlaces();
        }

        private void ComputeNetIncome()
        {
            this.NetIncome = (this.GrossIncome - this.IncomeTax).ToTwoDecimalPlaces();
        }

        private void ComputeSuper(int superRate)
        {
            var percentagedSuper = (double)superRate / 100;
            this.Super = (this.GrossIncome * percentagedSuper).ToTwoDecimalPlaces();
        }

        private void ComputeIncomeTax(double annualSalary)
        {
            var taxTier = GetTaxTier(annualSalary);
            var referencedSalary = annualSalary;
            var aggregatedTax = 0.0;

            // computes for income tax per tax tier
            for(int i = 1; i <= taxTier; i++)
            {
                aggregatedTax += TaxTierComputation(ref referencedSalary, i, annualSalary).ToTwoDecimalPlaces();
            }

            this.IncomeTax = (aggregatedTax / 12).ToTwoDecimalPlaces();
        }

        private int GetTaxTier(double annualSalary)
        {

            if (annualSalary <= 14000)
            {
                return 1;
            }

            if (annualSalary <= 48000)
            {
                return 2;
            }

            if (annualSalary <= 70000)
            {
                return 3;
            }

            if (annualSalary <= 180000)
            {
                return 4;
            }

            return 5;
        }

        private double TaxTierComputation(ref double taxableSalary, int taxTier, double totalSalary)
        {
            switch (taxTier)
            {
                case 1:
                    {
                        var result = totalSalary <= 14000 ? taxableSalary * 0.105 : 14000 * 0.105;

                        if (totalSalary > 14000)
                        {
                            taxableSalary -= 14000;
                        }

                        return result;
                    }
                case 2:
                    {
                        var result = totalSalary <= 48000 ? taxableSalary * 0.175 : (48000 - 14000) * 0.175;

                        if (totalSalary > 48000)
                        {
                            taxableSalary -= 34000;
                        }

                        return result;
                    }
                case 3:
                    {
                        var result = totalSalary <= 70000 ? taxableSalary * 0.3 : (70000 - 48000) * 0.3;

                        if (totalSalary > 70000)
                        {
                            taxableSalary -= 22000;
                        }

                        return result;
                    }
                case 4:
                    {
                        var result = totalSalary <= 180000 ? taxableSalary * 0.33 : (180000 - 70000) * 33;

                        if (totalSalary > 180000)
                        {
                            taxableSalary -= 110000;
                        }

                        return result;
                    }
                default:
                    {
                        var result = (taxableSalary - 180000) * 0.39;

                        return result;
                    }
            }
        }
    }
}
