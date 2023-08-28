using PayrollExercise.Models.Models.Payroll;
using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Messages.Response;

namespace PayrollExercise.Services.Services.Interface
{
    public interface IPayrollService
    {
        Task<BaseResponse<Employee>> GetEmployeePayroll(GetEmployeePayrollRequest request);
    }
}
