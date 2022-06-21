using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Management.System.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {

        private readonly IRezervManager rezervManager;
        private UserManager<User> _userManager;
        public DoctorController(UserManager<User> userManager, IRezervManager rezervManager)
        {
            this.rezervManager = rezervManager;
            this._userManager = userManager;

        }


        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var data = await rezervManager.GetMyRezervDoctor(user.Id);
            return View(data);
        }

        public IActionResult MyRezerv()
        {
            return View();
        }

    }
}
