using System.Text.Json.Serialization;

namespace Payroll.API.WebModels.Payroll
{
    public class PayrollDetails
    {
        /// <summary>
        /// Month Period of the Selected value
        /// </summary>
        /// <example>
        /// 01 March - 31 March
        /// </example>
        [JsonPropertyName("payPeriod")]
        public string PayPeriod { get; set; } = string.Empty;

        /// <summary>
        /// Gross Income base on input and computation
        /// </summary>
        /// <example>
        /// 1123.45
        /// </example>
        [JsonPropertyName("grossIncome")]
        public double GrossIncome { get; set; }

        /// <summary>
        /// Income Tax base on input and computation
        /// </summary>
        /// <example>
        /// 1123.45
        /// </example>
        [JsonPropertyName("incomeTax")]
        public double IncomeTax { get; set; }

        /// <summary>
        /// Net Income base on input and computation
        /// </summary>
        /// <example>
        /// 1123.45
        /// </example>
        [JsonPropertyName("netIncome")]
        public double NetIncome { get; set; }

        /// <summary>
        /// Super base on input and computation
        /// </summary>
        /// <example>
        /// 1123.45
        /// </example>
        [JsonPropertyName("super")]
        public double Super { get; set; }

        public PayrollDetails()
        {

        }

        public PayrollDetails(string payPeriod, double grossIncome, double incomeTax, double netIncome, double super)
        {
            PayPeriod = payPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
    }
}
