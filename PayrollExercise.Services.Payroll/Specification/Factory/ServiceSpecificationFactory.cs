using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.Base;
using PayrollExercise.Services.Payroll.Specification.GetEmployeePayrollSpecification;

namespace PayrollExercise.Services.Payroll.Specification.Factory
{
    public class ServiceSpecificationFactory : IServiceSpecificationFactory
    {
        public ISpecification<GetEmployeePayrollRequest> GetEmployeePayrollRequestSpecification(GetEmployeePayrollRequest request)
        {
            return new AnnualSalaryIsPositiveSpecification()
                    .And(new SuperRateWithinValidRange());
        }
    }
}
