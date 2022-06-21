using Hospital.Management.System.Entities.Concrete.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth
{
	public class LoginDTO : DtoBase
	{
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
