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
    public class DoctorDapper : IDoctorDapper
    {

        private readonly IUnitOfWork.IUnitOfWork unitOfWork;

        public DoctorDapper(IUnitOfWork.IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        private string GetAllNumber = @"select an.FirstName, an.LastName, an.Position,an.Experience ,an.Age,an.Id from AspNetUserRoles as anur
                                        inner join AspNetRoles as anr on anr.Id = anur.RoleId
                                        inner join AspNetUsers as an on an.Id = anur.UserId where anr.Name = 'Doctor'";
        private string DeleteDoctor = @"
                        DELETE FROM AspNetUserRoles WHERE UserId = @Id;
                        DELETE FROM [AspNetUsers] WHERE Id = @Id;";
        private string GetByIdDoctor = @" select anu.FirstName, anu.LastName, anu.Age, anu.Position, anu.Experience ,anu.Id from AspNetUsers as anu where Id = @id";
        private string UpadteDoctor = @"UPDATE [AspNetUsers]
   SET 
       [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Age] = @Age
      ,[Position] = @Position
      ,[Experience] = @Experience

  where Id = @Id";
       
        public async Task<List<Doctor>> AllDoctur()
        {
            try
            {

                var result = await unitOfWork.GetConnection().QueryAsync<Doctor>(GetAllNumber, null, unitOfWork.GetTransaction());


                return result.ToList();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> DeleteDoctur(int Id)
        {
           
            try
            {
                var param = new
                {
                    Id
                };

                await unitOfWork.GetConnection().QuerySingleAsync<string>(DeleteDoctor, param, unitOfWork.GetTransaction());

                return "Delete";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            
        }

        public async Task<Doctor> GetByIDDoctor(int id)
        {
            try
            {
                var param = new
                {
                    id
                };

                var data = await unitOfWork.GetConnection().QuerySingleAsync<Doctor>(GetByIdDoctor, param, unitOfWork.GetTransaction());

                return data;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<string> UpdateDoctor(Doctor doctor)
        {

            try
            {
                var param = new
                {
                    doctor.FirstName,
                    doctor.LastName,
                    doctor.Age,
                    doctor.Position,
                    doctor.Experience,
                    doctor.Id
                };

                await unitOfWork.GetConnection().QuerySingleAsync<string>(UpadteDoctor, param, unitOfWork.GetTransaction());

                return "Update";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

    }
}
