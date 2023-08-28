using Microsoft.AspNetCore.Mvc;
using Payroll.API.Extensions;
using Payroll.API.WebModels;
using Payroll.API.WebModels.BaseModels;
using Payroll.API.WebModels.Payroll;
using PayrollExercise.Services.Services.Interface;
using System.Net;

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
        /// <response code="200">Success GET</response>
        /// <response code="400">Request Validation Error</response>
        /// <response code="422">Request Validation Values Error</response>
        [HttpGet("payroll-details")]
        [ProducesResponseType(typeof(WebResponse<Employee>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPayrollDetails([FromQuery] GetEmployeePayrollWebRequest webRequest)
        {
            var result = await this._payrollService.GetEmployeePayroll(webRequest.ToServiceRequest());
            var actionResult = this.StatusCode(result.StatusCode, result.AsWebResponse());
            return actionResult;
        }
    }
}
