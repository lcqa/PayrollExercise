using PayrollExercise.Models.Constants;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Specification.GetEmployeePayrollSpecification
{
    public class SuperRateWithinValidRange : Specification<GetEmployeePayrollRequest>
    {
        public override bool IsSatisfied(GetEmployeePayrollRequest entity, List<string> errors)
        {
            var isSatisfied = true;

            if(entity.SuperRate < RateConstants.SuperRateFloorValue)
            {
                isSatisfied = false;
                errors.Add($"Super rate should not be lower than {RateConstants.SuperRateFloorValue}");
            }

            if(entity.SuperRate > RateConstants.SuperRateCeilingValue)
            {
                isSatisfied = false;
                errors.Add($"Super rate should not be higher than {RateConstants.SuperRateCeilingValue}");
            }

            return isSatisfied;
        }
    }
}
