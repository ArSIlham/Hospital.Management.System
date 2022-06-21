using Hospital.Management.System.Data.Dapper.Abstract;
using Hospital.Management.System.Data.Dapper.Concrete;
using Hospital.Management.System.Data.EntityFramework.Abstract;
using Hospital.Management.System.Data.EntityFramework.Concrete;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.IOC.Repositories
{
    public static class RepositoryRegistration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IDoctorRepository, DoctorRepository >();
            services.AddTransient<IDoctorDapper, DoctorDapper>();
            services.AddTransient<IRezervDapper, RezervDapper>();
            services.AddTransient<IRezervEFRepository, RezervEFRepository>();

        }
    }
}
