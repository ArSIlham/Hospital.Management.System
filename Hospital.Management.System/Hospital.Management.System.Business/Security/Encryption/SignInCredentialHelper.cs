using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Security.Encryption
{
	public class SignInCredentialHelper
	{
		public static SigningCredentials CreateSingingCredentials(SecurityKey key)
		{
			return new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
		}
	}
}
