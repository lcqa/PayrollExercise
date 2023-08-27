using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Specification.GetEmployeePayrollSpecification
{
    public class AnnualSalaryIsPositiveSpecification : Specification<GetEmployeePayrollRequest>
    {
        public override bool IsSatisfied(GetEmployeePayrollRequest entity, List<string> errors)
        {
            var isSatisfied = true;

            if(entity.AnnualSalary <= 0)
            {
                isSatisfied = false;
                errors.Add("Annual salary is not a positive value");
            }

            return isSatisfied;
        }
    }
}
