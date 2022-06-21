using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hospital.Management.System.Controllers
{
    [Authorize(Roles = "Consumer")]
    public class UserController : Controller
    {
        private readonly IRezervManager rezervManager;
        private UserManager<User> _userManager;
        private readonly IDoctorManager doctorManager;
        public UserController(UserManager<User> userManager, IRezervManager rezervManager, IDoctorManager doctorManager)
        {
            this.rezervManager = rezervManager;
            this._userManager = userManager;
            this.doctorManager = doctorManager;
        }

       
        public async Task<IActionResult> Index()
        {

            var data = await doctorManager.AllDoctur();

            return View(data);
        }
        public async Task<IActionResult> MyRezerv()
        {

            var user = _userManager.GetUserAsync(User).Result;
            var data = await rezervManager.GetUserAllRezerv(user.Id);

            return View(data);
        }
        [HttpGet]
        public IActionResult Rezerv(int id)
        {
            ViewBag.DcotorID = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rezerv(Rezerv rezerv)
        {
            var user = _userManager.GetUserAsync(User).Result;
            rezerv.UserId = user.Id;
            rezerv.DoctorId = rezerv.Id;
            rezerv.Id = 0;

            await rezervManager.AddRezerv(rezerv);
            return View();
        }
    }
}
