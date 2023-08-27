using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Services.Payroll;
using PayrollExercise.Services.Payroll.Specification.Factory;

namespace Payroll.API.Injections
{
    public static class PayrollServiceInjection
    {
        public static void InjectPayrollService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPayrollService, PayrollService>();
            services.AddScoped<IServiceSpecificationFactory, ServiceSpecificationFactory>();
        }
    }
}
