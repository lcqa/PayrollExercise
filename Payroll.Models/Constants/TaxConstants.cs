namespace PayrollExercise.Models.Constants
{
    public class TaxConstants
    {
        public const int TaxTierOneUpperLimit = 14000;
        public const int TaxTierTwoUpperLimit = 48000;
        public const int TaxTierThreeUpperLimit = 70000;
        public const int TaxTierFourUpperLimit = 180000;

        public const double TaxTierOnePercentRate = 0.105;
        public const double TaxTierTwoPercentRate = 0.175;
        public const double TaxTierThreePercentRate = 0.3;
        public const double TaxTierFourPercentRate = 0.33;
        public const double TaxTierFivePercentRate = 0.39;

        public static int GetTaxTier(double annualSalary)
        {

            if (annualSalary <= TaxTierOneUpperLimit)
            {
                return 1;
            }

            if (annualSalary <= TaxTierTwoUpperLimit)
            {
                return 2;
            }

            if (annualSalary <= TaxTierThreeUpperLimit)
            {
                return 3;
            }

            if (annualSalary <= TaxTierFourUpperLimit)
            {
                return 4;
            }

            return 5;
        }
    }
}
