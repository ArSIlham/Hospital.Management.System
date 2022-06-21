using Hospital.Management.System.Data.EntityFramework.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.EntityFramework.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext context;

        public DoctorRepository(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddDoctur(Doctor doctur)
        {
            var data =  context.Doctor.Add(doctur).Entity.Id;
            context.SaveChanges();
            return data;
        }

        public Task<Doctor> AllDoctur()
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDoctur(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditDoctur(Doctor doctur)
        {
            throw new NotImplementedException();
        }

     
    }
}
