using AutoMapper;
using Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Hospital.Management.System.Entities.DTOs.Concrete.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Mappers
{
	public class UserMapper : Profile
	{
		public UserMapper()
		{
            CreateMap<RegisterDTO, User>().ForMember(x => x.PasswordHash, opt => opt.Ignore());
            CreateMap<User, UserDTO>();
            CreateMap<UptadeUserDTO, User>();
        }
	}
}
