using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.Base;
using PayrollExercise.Services.Specification.GetEmployeePayrollSpecification;

namespace PayrollExercise.Services.Specification.Factory
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
