using Hospital.Management.System.Entities.Concrete.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth
{
	public class RegisterDTO : DtoBase
	{
		//Ad, Soyad, Yaş, Vəzifə, Təcrübə
		[Required(ErrorMessage = "User Name is required")]
		public string Username { get; set; }
		[EmailAddress]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public string Position { get; set; }
		public string Experience { get; set; }
        

    }
}
