using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Abstract
{
    public interface IRezervManager
    {
        
        Task<List<Rezerv>> GetRezervs(int Id);
        Task<List<DoctorRezerv>> GetMyRezervDoctor(int Id);
        Task<int> AddRezerv(Rezerv rezerv);
        Task<List<DoctorRezerv>> GetUserAllRezerv(int Id);



    }
}
