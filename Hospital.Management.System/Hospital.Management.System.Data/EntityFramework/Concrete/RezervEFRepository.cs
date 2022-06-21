using Hospital.Management.System.Data.EntityFramework.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.EntityFramework.Concrete
{
    public class RezervEFRepository : IRezervEFRepository
    {
        private readonly HospitalDbContext context;

        public RezervEFRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddRezerv(Rezerv rezerv)
        {
            context.Rezerv.Add(rezerv);
            context.SaveChanges();
            return 1;
        }
    }
}
