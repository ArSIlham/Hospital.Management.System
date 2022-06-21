using AutoWrapper.Wrappers;
using Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Abstract
{
    public interface IAuthManager
    {
        Task<ApiResponse> Register(RegisterDTO registerDto);

        Task<ApiResponse> Login(LoginDTO registerDto);
        Task LogOut();
        Task<ApiResponse> UptadeUser(UptadeUserDTO userUpdateDTO);

    }
}
