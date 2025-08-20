using ITI_Training_Hospital_System.Models.Data;
using ITI_Training_Hospital_System.Models.Entites;
using ITI_Training_Hospital_System.Models.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Training_Hospital_System.Controllers
{
    [Authorize]
    public class HospitalController : Controller
    {

        private readonly AppDbContext _dbContext;

        public HospitalController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var hospitals = _dbContext.Hospitals.ToList();
            return View(hospitals);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HospitalVM hospitalViewModel)
        {
            if (ModelState.IsValid)
            {
                var hospital = new Hospital
                {

                    Name = hospitalViewModel.Name,
                    Address = hospitalViewModel.Address,
                    City = hospitalViewModel.City,
                    
                };
                _dbContext.Hospitals.Add(hospital);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalViewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var hospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == id);
            if (hospital == null)
            {
                return NotFound("Not Found: 404");
            }

            return View(hospital);
        }
        [HttpPost]
        public IActionResult Update(HospitalVM hospitalvm)
        {
            if (ModelState.IsValid)
            {
                var existingHospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == hospitalvm.Id);
                if (existingHospital == null)
                {
                    return NotFound("Not Found: 404");
                }
                existingHospital.Name = hospitalvm.Name;
                existingHospital.Address = hospitalvm.Address;
                existingHospital.City = hospitalvm.City;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var hospital = _dbContext.Hospitals
                .Include(h => h.Patients) 
                .FirstOrDefault(h => h.Id == id);

            if (hospital == null)
            {
                return NotFound("Not Found: 404");
            }

            return View(hospital);
        }

        public IActionResult Delete(int id)
        {
            var hospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == id);
            if (hospital == null)
            {
                return NotFound("Not Found: 404");
            }
            TempData["Deletes"] = hospital.Name;
            _dbContext.Hospitals.Remove(hospital);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");

        }




    }
}
