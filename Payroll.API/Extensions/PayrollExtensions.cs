using Payroll.API.WebModels.BaseModels;
using PayrollExercise.Services.Messages.Response;
using Models = PayrollExercise.Models.Models.Payroll;
using ViewModels = Payroll.API.WebModels;

namespace Payroll.API.Extensions
{
    public static class PayrollExtensions
    {
        public static WebResponse<ViewModels.Payroll.Employee> AsWebResponse(this BaseResponse<Models.Employee> response)
        {
            return new WebResponse<ViewModels.Payroll.Employee>()
            {
                Data = new ViewModels.Payroll.Employee()
                {
                    FirstName = response.Data.FirstName,
                    LastName = response.Data.LastName,
                    PayrollDetails = new ViewModels.Payroll.PayrollDetails()
                    {
                        IncomeTax = response.Data.PayrollDetails.IncomeTax,
                        GrossIncome = response.Data.PayrollDetails.GrossIncome,
                        NetIncome = response.Data.PayrollDetails.NetIncome,
                        PayPeriod = response.Data.PayrollDetails.PayPeriod,
                        Super = response.Data.PayrollDetails.Super
                    }
                },
                Message = response.Message,
                StatusCode = response.StatusCode
            };
        }
    }
}
