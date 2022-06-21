using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Data.Dapper.Abstract;
using Hospital.Management.System.Data.EntityFramework.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Concrete
{
    public class RezervManager : IRezervManager
    {
        private readonly IRezervEFRepository rezervEfRepository;
        private readonly IRezervDapper rezerv;

        public RezervManager(IRezervEFRepository rezervEfRepository, IRezervDapper rezerv)
        {
            this.rezervEfRepository = rezervEfRepository;
            this.rezerv = rezerv;
        }
        public async Task<int> AddRezerv(Rezerv rezerv)
        {
           await rezervEfRepository.AddRezerv(rezerv);
            return 1;
        }

        public async Task<List<DoctorRezerv>> GetMyRezervDoctor(int Id)
        {
            var data = await rezerv.GetMyRezervDoctor(Id);
            return data;
        }

        public async Task<List<Rezerv>> GetRezervs(int Id)
        {
            var data = await rezerv.GetRezervs(Id);
            return data;
            
        }

        public async Task<List<DoctorRezerv>> GetUserAllRezerv(int Id)
        {
            var data = await rezerv.GetUserAllRezerv(Id);
            return data;
        }
    }
}
