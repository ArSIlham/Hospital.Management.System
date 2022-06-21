using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.EntityFramework
{
    public class HospitalDbContext : IdentityDbContext<User, Role, int>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
            {

            }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Rezerv> Rezerv { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
