using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.Base;

namespace PayrollExercise.Services.Specification.Factory
{
    public interface IServiceSpecificationFactory
    {
        ISpecification<GetEmployeePayrollRequest> GetEmployeePayrollRequestSpecification(GetEmployeePayrollRequest request);
    }
}
