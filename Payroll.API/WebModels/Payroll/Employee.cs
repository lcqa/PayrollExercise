using PayrollExercise.Models.Models.Payroll;
using System.Text.Json.Serialization;

namespace Payroll.API.WebModels.Payroll
{
    public class Employee
    {
        /// <summary>
        /// First name of the Employee
        /// </summary>
        /// <example>
        /// John
        /// </example>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// First name of the Employee
        /// </summary>
        /// <example>
        /// Smith
        /// </example>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Payroll Details of the employee
        /// </summary>
        [JsonPropertyName("payrollDetails")]
        public PayrollDetails PayrollDetails { get; set; }

        public Employee()
        {

        }

        public Employee(string firstName, string lastName, PayrollDetails payrollDetails)
        {
            FirstName = firstName;
            LastName = lastName;
            PayrollDetails = payrollDetails;
        }
    }
}
