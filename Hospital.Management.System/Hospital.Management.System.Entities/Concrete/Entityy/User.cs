using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Entities.Concrete.Entityy
{
    public class User : IdentityUser<int>
    {
	
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public string Position { get; set; }
		public string Experience { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;


	}
}
