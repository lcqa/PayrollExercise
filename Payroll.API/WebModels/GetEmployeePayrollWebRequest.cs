using PayrollExercise.Services.Messages.Request.Payroll;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Payroll.API.WebModels
{
    public class GetEmployeePayrollWebRequest
    {
        /// <summary>
        /// First name of the employee
        /// </summary>
        /// <example>
        /// John
        /// </example>
        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the employee
        /// </summary>
        /// <example>
        /// Smith
        /// </example>
        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Total Annual Salary of the employee
        /// </summary>
        /// <example>
        /// 60000.00
        /// </example>
        [Required]
        [JsonPropertyName("annualSalary")]
        public double? AnnualSalary { get; set; }

        /// <summary>
        /// Super Rate % of the employee
        /// </summary>
        /// <example>
        /// 9
        /// </example>
        [Required]
        [Range(minimum: 0, maximum: 50, ErrorMessage = "Valid values are from 0 to 50")]
        [JsonPropertyName("superRate")]
        public int? SuperRate { get; set; }

        /// <summary>
        /// Month Pay Period
        /// </summary>
        /// <example>
        /// 3
        /// </example>
        [Required]
        [Range(minimum: 1, maximum: 12, ErrorMessage = "Please provide a valid value")]
        [JsonPropertyName("payPeriod")]
        public int PayPeriod { get; set; }

        public GetEmployeePayrollRequest ToServiceRequest()
        {
            return new GetEmployeePayrollRequest
            {
                FirstName = FirstName,
                LastName = LastName,
                PayPeriod = PayPeriod,
                SuperRate = SuperRate.GetValueOrDefault(),
                AnnualSalary = AnnualSalary.GetValueOrDefault(),
            };
        }
    }
}
