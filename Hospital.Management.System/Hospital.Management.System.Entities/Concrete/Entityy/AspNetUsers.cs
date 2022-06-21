using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Entities.Concrete.Entityy
{
    public class AspNetUsers
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string About { get; set; }
		public string ImagePath { get; set; }
		public string ImagePublicId { get; set; }
		public DateTime RegistrationDate { get; set; }
		public DateTime DOB { get; set; }
		public int Id { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
	}
}
