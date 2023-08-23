using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Models.Messages.Response;
using PayrollExercise.Models.Models.Payroll;

namespace Payroll.Infrastructure.Services
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
