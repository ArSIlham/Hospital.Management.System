using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.Dapper.Abstract
{
    public interface IDoctorDapper
    {
        Task<List<Doctor>> AllDoctur();
        Task<string> DeleteDoctur(int Id);
        Task<Doctor> GetByIDDoctor(int id);
        Task<string> UpdateDoctor(Doctor doctor);
    }
}
