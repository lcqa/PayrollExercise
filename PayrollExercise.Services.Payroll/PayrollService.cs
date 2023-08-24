using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Infrastructure.Exceptions;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Models.Messages.Response;
using PayrollExercise.Models.Models.Payroll;
using System.Net;

namespace PayrollExercise.Services.Payroll
{
    public class PayrollService : IPayrollService
    {
        public async Task<BaseResponse<Employee>> GetEmployeePayroll(GetEmployeePayrollRequest request)
        {
            var result = new BaseResponse<Employee>();

            try
            {
                var employee = new Employee(request.FirstName, request.LastName);
                employee.ComputePayrollDetails(request.AnnualSalary, request.SuperRate, request.PayPeriod);

                result.Data = employee;
                result.StatusCode = (int)HttpStatusCode.OK;

            }
            catch (Exception e)
            {
                throw new PayrollServiceException(e.Message, e.InnerException);
            }

            return result;
        }
    }
}
