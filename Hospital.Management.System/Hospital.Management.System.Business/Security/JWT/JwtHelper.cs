using AutoWrapper.Wrappers;
using Hospital.Management.System.Business.Extensions;
using Hospital.Management.System.Business.Security.Encryption;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace Hospital.Management.System.Business.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private JwtSetting _jwtSetting;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;

            _jwtSetting = Configuration.GetSection("Jwt").Get<JwtSetting>();
        }

        public AccessToken CreateToken(User user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_jwtSetting.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_jwtSetting.Key);
            var signInCredentials = SignInCredentialHelper.CreateSingingCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_jwtSetting, user, signInCredentials);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                UserId = user.Id.ToString()
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(JwtSetting jwtSetting, User user,
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                 issuer: jwtSetting.Issuer,
                 audience: jwtSetting.Audience,
                 expires: _accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: SetClaims(user),
                 signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            string[] roles = { "Consumer" };
            var claims = new List<Claim>();
            claims.AddName(user.Id.ToString());
            claims.AddNameIdentifier($"{user.FirstName} {user.LastName}");
            claims.AddRoles(roles);

            return claims;
        }

        public int? ValidateJwtToken(string token, string[] roles)
        {
            Console.WriteLine(token);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSetting.Key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value);
                var role = jwtToken.Claims.First(x => x.Type == @"http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value.ToUpper();

                if (roles.Contains(role))
                {
                    return accountId;
                }
                else throw new Exception("User not in role");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // return null if validation fails
                throw new ApiException(ex.Message);
            }
        }
    }
}
