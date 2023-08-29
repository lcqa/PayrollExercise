namespace PayrollExercise.Models.Constants
{
    public enum TaxTier
    {
        One = 1, 
        Two = 2, 
        Three = 3, 
        Four = 4, 
        Five = 5
    }

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
                return (int)TaxTier.One;
            }

            if (annualSalary <= TaxTierTwoUpperLimit)
            {
                return (int)TaxTier.Two;
            }

            if (annualSalary <= TaxTierThreeUpperLimit)
            {
                return (int)TaxTier.Three;
            }

            if (annualSalary <= TaxTierFourUpperLimit)
            {
                return (int)TaxTier.Four;
            }

            return (int)TaxTier.Five;
        }
    }
}
