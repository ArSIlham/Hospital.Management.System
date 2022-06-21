using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.EntityFramework.Abstract
{
    public interface IRezervEFRepository
    {

        Task<int> AddRezerv(Rezerv rezerv);

    }
}
