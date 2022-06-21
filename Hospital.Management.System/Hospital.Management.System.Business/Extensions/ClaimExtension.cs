using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Extensions
{
	public static class ClaimExtension
	{
		public static void AddEmail(this ICollection<Claim> claims, string email)
		{
			claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
		}

		public static void AddName(this ICollection<Claim> claims, string id)
		{
			claims.Add(new Claim(ClaimTypes.Name, id));
		}

		public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
		{
			claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
		}

		public static void AddRoles(this ICollection<Claim> claims, string[] roles)
		{
			foreach (var item in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, item));
			}
		}
	}
}
