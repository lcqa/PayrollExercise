using PayrollExercise.Models.Constants;
using PayrollExercise.Models.Extensions;
using System.Globalization;

namespace PayrollExercise.Models.Models.Payroll
{
    public class PayrollDetails
    {
        //Month
        public string PayPeriod { get; set; } = string.Empty;

        public double GrossIncome { get; private set; }

        public double IncomeTax { get; private set; }

        public double NetIncome { get; private set; }

        public double Super { get; private set; }

        public PayrollDetails()
        {

        }

        public PayrollDetails(double annualSalary, int superRate, int month)
        {
            ParsePayPeriod(month);
            ComputeGrossIncome(annualSalary);
            ComputeIncomeTax(annualSalary);
            ComputeNetIncome();
            ComputeSuper(superRate);
        }

        private void ParsePayPeriod(int month)
        {
            var dateTime = new DateTime(DateTime.Now.Year, month, 1);
            var monthString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            this.PayPeriod = $"01 {monthString} - {dateTime.AddMonths(1).AddDays(-1).ToString("dd")} {monthString}";
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
            var taxTier = TaxConstants.GetTaxTier(annualSalary);
            var referencedSalary = annualSalary;
            var aggregatedTax = 0.0;

            // computes for income tax per tax tier
            for (int i = 1; i <= taxTier; i++)
            {
                aggregatedTax += TaxTierComputation(ref referencedSalary, i, annualSalary).ToTwoDecimalPlaces();
            }

            this.IncomeTax = (aggregatedTax / 12).ToTwoDecimalPlaces();
        }

        private double TaxTierComputation(ref double taxableSalary, int taxTier, double totalSalary)
        {
            switch (taxTier)
            {
                case 1:
                    {
                        var result = totalSalary <= TaxConstants.TaxTierOneUpperLimit ? taxableSalary * TaxConstants.TaxTierOnePercentRate : TaxConstants.TaxTierOneUpperLimit * TaxConstants.TaxTierOnePercentRate;

                        if (totalSalary > TaxConstants.TaxTierOneUpperLimit)
                        {
                            taxableSalary -= TaxConstants.TaxTierOneUpperLimit;
                        }

                        return result;
                    }
                case 2:
                    {
                        var result = totalSalary <= TaxConstants.TaxTierTwoUpperLimit ? taxableSalary * TaxConstants.TaxTierTwoPercentRate : (TaxConstants.TaxTierTwoUpperLimit - TaxConstants.TaxTierOneUpperLimit) * TaxConstants.TaxTierTwoPercentRate;

                        if (totalSalary > TaxConstants.TaxTierTwoUpperLimit)
                        {
                            taxableSalary -= TaxConstants.TaxTierTwoUpperLimit - TaxConstants.TaxTierOneUpperLimit;
                        }

                        return result;
                    }
                case 3:
                    {
                        var result = totalSalary <= TaxConstants.TaxTierThreeUpperLimit ? taxableSalary * TaxConstants.TaxTierThreePercentRate : (TaxConstants.TaxTierThreeUpperLimit - TaxConstants.TaxTierTwoUpperLimit) * TaxConstants.TaxTierThreePercentRate;

                        if (totalSalary > TaxConstants.TaxTierThreeUpperLimit)
                        {
                            taxableSalary -= TaxConstants.TaxTierThreeUpperLimit - TaxConstants.TaxTierTwoUpperLimit;
                        }

                        return result;
                    }
                case 4:
                    {
                        var result = totalSalary <= TaxConstants.TaxTierFourUpperLimit ? taxableSalary * TaxConstants.TaxTierFourPercentRate : (TaxConstants.TaxTierFourUpperLimit - TaxConstants.TaxTierThreeUpperLimit) * TaxConstants.TaxTierFourPercentRate;

                        if (totalSalary > TaxConstants.TaxTierFourUpperLimit)
                        {
                            taxableSalary -= TaxConstants.TaxTierFourUpperLimit - TaxConstants.TaxTierThreeUpperLimit;
                        }

                        return result;
                    }
                default:
                    {
                        var result = (taxableSalary - TaxConstants.TaxTierFourUpperLimit) * TaxConstants.TaxTierFivePercentRate;

                        return result;
                    }
            }
        }
    }
}
