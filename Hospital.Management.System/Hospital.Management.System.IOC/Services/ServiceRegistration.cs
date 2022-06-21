using Hospital.Management.System.Business.Security.JWT;
using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Business.Services.Concrete;
using Hospital.Management.System.Data.IUnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.IOC.Services
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();  
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();
            services.AddTransient<IDoctorManager, DoctorManager>();
            services.AddTransient<IRezervManager, RezervManager>();
        }
    }
}
