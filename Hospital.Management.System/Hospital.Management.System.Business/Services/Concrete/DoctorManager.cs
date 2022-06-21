using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Data.Dapper.Abstract;
using Hospital.Management.System.Data.EntityFramework.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Concrete
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IDoctorDapper doctorDapper;

        public DoctorManager(IDoctorRepository doctorRepository, IDoctorDapper doctorDapper)
        {
            this.doctorRepository = doctorRepository;
            this.doctorDapper = doctorDapper;
        }


        public async Task<int> AddDoctur(Doctor doctur)
        {
            return await doctorRepository.AddDoctur(doctur);
        }

        public async Task<List<Doctor>> AllDoctur()
        {
            var data = doctorDapper.AllDoctur();
            return data.Result;
        }

        public async Task<string> DeleteDoctur(int Id)
        {
            await doctorDapper.DeleteDoctur(Id);
            return "(*_*)";
        }

        public Task<string> EditDoctur(Doctor doctur)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetByIDDoctor(int id)
        {
          var data =  await doctorDapper.GetByIDDoctor(id);
            return data;
        }

        public async Task<string> UpdateDoctor(Doctor doctor)
        {
            await doctorDapper.UpdateDoctor(doctor);
            return "";
        }
    }
}
