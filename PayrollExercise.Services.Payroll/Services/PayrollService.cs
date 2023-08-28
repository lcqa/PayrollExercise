using PayrollExercise.Models.Models.Payroll;
using PayrollExercise.Services.Exceptions;
using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Messages.Response;
using PayrollExercise.Services.Services.Interface;
using PayrollExercise.Services.Specification.Factory;
using System.Net;

namespace PayrollExercise.Services.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IServiceSpecificationFactory _serviceSpecificationFactory;

        public PayrollService(IServiceSpecificationFactory serviceSpecificationFactory)
        {
            _serviceSpecificationFactory = serviceSpecificationFactory;
        }

        public async Task<BaseResponse<Employee>> GetEmployeePayroll(GetEmployeePayrollRequest request)
        {
            var result = new BaseResponse<Employee>();

            try
            {
                var errorList = new List<string>();
                var specification = _serviceSpecificationFactory.GetEmployeePayrollRequestSpecification(request);
                if (!specification.IsSatisfied(request, errorList))
                {
                    result.Message = string.Join(',', errorList);
                    result.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    return result;
                }

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
