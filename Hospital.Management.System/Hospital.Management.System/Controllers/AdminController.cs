using Hospital.Management.System.Business.Services.Abstract;
using Hospital.Management.System.Entities.Concrete.Entityy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Web API edecekdim ama vaxt limitini ola bileceyini dusunduyum ucun MVC dondum 
/// </summary>
namespace Hospital.Management.System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IDoctorManager doctorManager;

        public AdminController(IDoctorManager doctorManager)
        {
            this.doctorManager = doctorManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await doctorManager.AllDoctur();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctur(Doctor doctur)
        {
            await doctorManager.AddDoctur(doctur);
            return RedirectToAction("Index","Admin");
        }
        [HttpGet]
        public async Task<IActionResult> GetByIDDoctor(int Id)
        {
            var data = await doctorManager.GetByIDDoctor(Id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditDoctur(Doctor doctur)
        {
            await doctorManager.UpdateDoctor(doctur);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> DeleteDoctur(int Id)
        {
           await doctorManager.DeleteDoctur(Id);
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> AllDoctur()
        {
           var data =  await doctorManager.AllDoctur();
            return View(data);
        }
    }
}
