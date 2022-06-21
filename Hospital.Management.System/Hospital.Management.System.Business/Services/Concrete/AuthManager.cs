using AutoMapper;
using AutoWrapper.Wrappers;
using Hospital.Management.System.Business.Security.JWT;
using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Data.IUnitOfWork;
using Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Management.System.Business.Services.Concrete
{
	public class AuthManager : IAuthManager
	{
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly RoleManager<Role> roleManager;
		private readonly IUnitOfWork unitOfWork;
		private readonly SignInManager<User> signInManager;
		private readonly ITokenHelper tokenHelper;


		public AuthManager(IMapper mapper, UserManager<User> userManager,
			RoleManager<Role> roleManager,
			IUnitOfWork unitOfWork,
			SignInManager<User> signInManager, ITokenHelper tokenHelper )
		{
			this.mapper = mapper;
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.unitOfWork = unitOfWork;
			this.signInManager = signInManager;
			this.tokenHelper = tokenHelper;


		}

		public async Task LogOut()
		{
			await signInManager.SignOutAsync();
		}

		public async Task<ApiResponse> Login(LoginDTO registerDto)
		{
			var user = await userManager.FindByNameAsync(registerDto.Username);
			if (user == null) return new ApiResponse(400, new ApiError("Login failed"));
			var result = await signInManager.PasswordSignInAsync(user.UserName, registerDto.Password, false, false);

			if (result.Succeeded)
			{

				var data = tokenHelper.CreateToken(user);
				return new ApiResponse(data); ;
			}
			else return new ApiResponse(400, new ApiError("Login failed"));
		}

		public async Task<ApiResponse> Register(RegisterDTO registerDto)
		{
			try
			{
				var user = await userManager.FindByEmailAsync(registerDto.Email);

				if (user != null) return new ApiResponse(400, $"Email '{registerDto.Email}' is already taken.");

				var tempUser = mapper.Map<User>(registerDto);

				var result = await userManager.CreateAsync(tempUser, registerDto.Password);
				if (!result.Succeeded)
				{
					throw new ApiException(IdentityErrors(result.Errors));
				}
				else
				{
					var userfromDb = await userManager.FindByNameAsync(registerDto.Username);
					if (userfromDb != null)
					{
						var userRole = await roleManager.FindByNameAsync("Consumer");

						if (userRole == null)
						{
							var res = await roleManager.CreateAsync(new Role { Name = "Consumer" });
							if (res.Succeeded)
							{
								var roleresult = await userManager.AddToRoleAsync(userfromDb, "Consumer");
								if (!roleresult.Succeeded)
								{
									throw new ApiException(IdentityErrors(result.Errors));
								}
							}
							else
							{
								throw new ApiException(IdentityErrors(result.Errors));
							}
						}
					}
				}

				return new ApiResponse($"{registerDto.Email} succesfully registreted");
			}
			catch (ApiException apiex)
			{

				return new ApiResponse(400, $"Username '{registerDto.Username}' is already taken.");
			}
			catch (Exception ex)
			{
				throw new ApiException(ex.Message);
			}
		}

		private IEnumerable<ValidationError> IdentityErrors(IEnumerable<IdentityError> items)
		{
			List<ValidationError> errors = new List<ValidationError>();
			foreach (var item in items)
			{
				errors.Add(new ValidationError(item.Code, item.Description));

				Console.WriteLine(item.Description);
			}

			return errors;
		}

		public async Task<ApiResponse> UptadeUser(UptadeUserDTO userUpdateDTO)
		{
			try
			{
				var data = await userManager.FindByIdAsync(userUpdateDTO.Id.ToString());

				data.FirstName = userUpdateDTO.FirstName;
				data.LastName = userUpdateDTO.LastName;

				await userManager.UpdateAsync(data);

				return new ApiResponse("Succesfully done");
			}
			catch (Exception ex)
			{
				throw new ApiException(ex.Message);
			}
		}

		public async Task<string> ResetPassword(string ID, string Password)
		{
			try
			{
				var data = await userManager.FindByIdAsync(ID.ToString());
				var token = await userManager.GeneratePasswordResetTokenAsync(data);

				if (Password != string.Empty || Password != null)
				{
					await userManager.ResetPasswordAsync(data, token, Password);
				}
				return "Succesfully done";

			}
			catch (Exception ex)
			{

				throw new ApiException(ex.Message);
			}
		}
	}
}
