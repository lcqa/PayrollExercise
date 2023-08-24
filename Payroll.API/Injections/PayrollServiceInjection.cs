using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Services.Payroll;

namespace Payroll.API.Injections
{
    public static class PayrollServiceInjection
    {
        public static void InjectPayrollService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPayrollService, PayrollService>();
        }
    }
}
