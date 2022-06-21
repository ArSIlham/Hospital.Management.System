using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.EntityFramework.Abstract
{
    public interface IDoctorRepository
    {
        Task<int> AddDoctur(Doctor doctur);
        Task<string> EditDoctur(Doctor doctur);
        Task<string> DeleteDoctur(int Id);
        Task<Doctor> AllDoctur();
     
    }
}
