using Hospital.Management.System.Entities.Concrete.DTOs.Concrete.Auth;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Hospital.Management.System.Entities.DTOs.Concrete.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital.Management.System.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public AccountController(SignInManager<User> signInManager,
            UserManager<User> userManager, RoleManager<Role> roleManager)
        {

            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
    
        public async Task<IActionResult> LoginAsync()
        {

            return View();
        }
        public async Task<IActionResult> CreateAccount(RegisterDTO user, string Role)
        {
            if (user.Username == string.Empty || user.Password == string.Empty)
            {
                return View(user);
            }
            User appUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Experience = user.Experience,
                Position = user.Position,
                UserName = user.Username,
                NormalizedUserName = user.Username
            };


            var result = await userManager.CreateAsync(appUser, user.Password);


            if (result.Succeeded)
            {
              
              


                var userfromDb = await userManager.FindByNameAsync(appUser.UserName);
                await userManager.AddToRoleAsync(userfromDb, Role);
                if (Role == "Doctor")
                {
                    return RedirectToAction("Index", "Admin");

                }
                await signInManager.PasswordSignInAsync(appUser, user.Password, false, false);

                var user1 = await userManager.FindByNameAsync(user.Username);
                if (user1 != null)
                {


                    var result1 = await signInManager.PasswordSignInAsync(user1, user.Password, false, false);
                    if (result1.Succeeded)
                    {
                        var role = userManager.GetRolesAsync(user1).Result.FirstOrDefault();
                        if (role == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (role == "Doctor")
                        {
                            return RedirectToAction("Index", "Doctor");
                        }
                        else
                        {
                            return RedirectToAction("Index", "User");

                        }

                    }



                }
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Accsess(LoginDTO userr)
        {

            var user = await userManager.FindByNameAsync(userr.Username);
            if (user != null)
            {


                var result = await signInManager.PasswordSignInAsync(user, userr.Password, false, false);
                if (result.Succeeded)
                {
                    var role = userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    if (role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (role == "Doctor")
                    {
                        return RedirectToAction("Index", "Doctor");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");

                    }

                }



            }
            return RedirectToAction("Login", "Account");

        }
        public async Task<IActionResult> Logout()
        {
             await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
