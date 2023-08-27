using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Specification.Factory
{
    public interface IServiceSpecificationFactory
    {
        ISpecification<GetEmployeePayrollRequest> GetEmployeePayrollRequestSpecification(GetEmployeePayrollRequest request); 
    }
}
