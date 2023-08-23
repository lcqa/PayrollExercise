using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Models.Messages.Response;
using PayrollExercise.Models.Models.Payroll;

namespace Payroll.Infrastructure.Interfaces
{
    public interface IPayrollService
    {
        Task<BaseResponse<EmployeePayroll>> GetEmployeePayroll(GetEmployeePayrollRequest request);
    }
}
