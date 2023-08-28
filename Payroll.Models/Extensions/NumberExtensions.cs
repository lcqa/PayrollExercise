namespace PayrollExercise.Models.Extensions
{
    public static class NumberExtensions
    {
        public static double ToTwoDecimalPlaces(this double value)
        {
            return Math.Round(value, 2);
        }
    }
}
