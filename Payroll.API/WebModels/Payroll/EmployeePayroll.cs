using System.Text.Json.Serialization;

namespace Payroll.API.WebModels.Payroll
{
    public class EmployeePayroll
    {
        [JsonPropertyName("payPeriod")]
        public string PayPeriod { get; set; } = string.Empty;

        [JsonPropertyName("grossIncome")]
        public double GrossIncome { get; set; }

        [JsonPropertyName("incomeTax")]
        public double IncomeTax { get; set; }

        [JsonPropertyName("netIncome")]
        public double NetIncome { get; set; }

        [JsonPropertyName("super")]
        public double Super { get; set; }

        public EmployeePayroll()
        {

        }

        public EmployeePayroll(string payPeriod, double grossIncome, double incomeTax, double netIncome, double super)
        {
            PayPeriod = payPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }
    }
}
