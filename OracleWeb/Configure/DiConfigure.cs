using OracleWeb.Interfaces;
using OracleWeb.Models;
using OracleWeb.Services;

namespace OracleWeb.Configure
{
    public static class DatabaseConfig
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((_) => new ModelContext());
            services.AddScoped<IPayrollServices, PayrollServices>();
            services.AddScoped<IPositionServices, PositionServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<ITimekeepingServices, TimekeepingServices>();
        }
    }
 }

