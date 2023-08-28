using PayrollExercise.Services.Services;
using PayrollExercise.Services.Services.Interface;
using PayrollExercise.Services.Specification.Factory;

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
