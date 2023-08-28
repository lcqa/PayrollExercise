using PayrollExercise.Models.Constants;
using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.Base;

namespace PayrollExercise.Services.Specification.GetEmployeePayrollSpecification
{
    public class SuperRateWithinValidRange : Specification<GetEmployeePayrollRequest>
    {
        public override bool IsSatisfied(GetEmployeePayrollRequest entity, List<string> errors)
        {
            var isSatisfied = true;

            if (entity.SuperRate < RateConstants.SuperRateFloorValue)
            {
                isSatisfied = false;
                errors.Add($"Super rate should not be lower than {RateConstants.SuperRateFloorValue}");
            }

            if (entity.SuperRate > RateConstants.SuperRateCeilingValue)
            {
                isSatisfied = false;
                errors.Add($"Super rate should not be higher than {RateConstants.SuperRateCeilingValue}");
            }

            return isSatisfied;
        }
    }
}
