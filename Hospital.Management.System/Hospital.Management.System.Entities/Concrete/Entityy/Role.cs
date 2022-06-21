using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Entities.Concrete.Entityy
{
	public class Role : IdentityRole<int>
	{
		public DateTime CreationDate { get; set; }
		public int CreatorId { get; set; }
	}
}
