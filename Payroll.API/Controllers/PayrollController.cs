using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payroll.API.WebModels;
using Payroll.Infrastructure.Interfaces;

namespace Payroll.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        /// <summary>
        /// Computes the payroll of the given Employee data
        /// </summary>
        /// <param name="webRequest"></param>
        /// <returns></returns>
        [HttpGet("payroll-details")]
        public async Task<IActionResult> GetPayrollDetails([FromQuery]GetEmployeePayrollWebRequest webRequest)
        {
            var result = await this._payrollService.GetEmployeePayroll(webRequest.ToServiceRequest());
            var actionResult = this.StatusCode(result.StatusCode,result);
            return actionResult;
        }
    }
}
