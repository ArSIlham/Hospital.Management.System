using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.Dapper.Abstract
{
    public interface IRezervDapper
    {
        Task<List<DoctorRezerv>> GetMyRezervDoctor(int Id);
        Task<List<Rezerv>> GetRezervs(int Id);
        Task<List<DoctorRezerv>> GetUserAllRezerv(int Id);


    }
}
