using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Abstract
{
    public interface IDoctorManager
    {
        Task<int> AddDoctur(Doctor doctur);
        Task<string> EditDoctur(Doctor doctur);
        Task<string> DeleteDoctur(int Id);
        Task<List<Doctor>> AllDoctur();
        Task<Doctor> GetByIDDoctor(int id);
        Task<string> UpdateDoctor(Doctor doctor);



    }
}
