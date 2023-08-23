using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Models.Messages.Response;
using PayrollExercise.Models.Models.Payroll;

namespace PayrollExercise.Services.Payroll
{
    public class PayrollService : IPayrollService
    {
        public async Task<BaseResponse<EmployeePayroll>> GetEmployeePayroll(GetEmployeePayrollRequest request)
        {
            var result = new BaseResponse<EmployeePayroll>();
            return result;
        }
    }
}
