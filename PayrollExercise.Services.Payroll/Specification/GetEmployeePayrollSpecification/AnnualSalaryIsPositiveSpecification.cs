using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.Base;

namespace PayrollExercise.Services.Specification.GetEmployeePayrollSpecification
{
    public class AnnualSalaryIsPositiveSpecification : Specification<GetEmployeePayrollRequest>
    {
        public override bool IsSatisfied(GetEmployeePayrollRequest entity, List<string> errors)
        {
            var isSatisfied = true;

            if (entity.AnnualSalary <= 0)
            {
                isSatisfied = false;
                errors.Add("Annual salary is not a positive value");
            }

            return isSatisfied;
        }
    }
}
