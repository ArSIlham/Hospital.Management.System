using Dapper;
using Hospital.Management.System.Data.Dapper.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Data.Dapper.Concrete
{
    public class RezervDapper : IRezervDapper
    {
        private readonly IUnitOfWork.IUnitOfWork unitOfWork;

        public RezervDapper(IUnitOfWork.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        private string GetAllRezervSql = "select * from Rezerv where Id = @Id;";
        private string GetMyAllRezervSql = @"select anu.FirstName,anu.LastName,Rezerv.Bron from Rezerv 
inner join AspNetUsers as anu on anu.Id = Rezerv.UserId where Rezerv.DoctorId = @Id;";

        private string GetUserRezervsAll = @"select anu.FirstName, anu.LastName, Rezerv.Bron from Rezerv
        inner join AspNetUsers as anu on anu.Id = Rezerv.DoctorID where Rezerv.UserID = @Id;";
        

        public async Task<List<Rezerv>> GetRezervs(int Id)
        {
            try
            {
                var param = new
                {

                    Id
                };

                var result = await unitOfWork.GetConnection().QueryAsync<Rezerv>(GetAllRezervSql, param, unitOfWork.GetTransaction());


                return result.ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<DoctorRezerv>> GetMyRezervDoctor(int Id)
        {
            try
            {
                var param = new
                {

                    Id
                };

                var result = await unitOfWork.GetConnection().QueryAsync<DoctorRezerv>(GetMyAllRezervSql, param, unitOfWork.GetTransaction());


                return result.ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<List<DoctorRezerv>> GetUserAllRezerv(int Id)
        {
            try
            {
                var param = new
                {

                    Id
                };

                var result = await unitOfWork.GetConnection().QueryAsync<DoctorRezerv>(GetUserRezervsAll, param, unitOfWork.GetTransaction());


                return result.ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
