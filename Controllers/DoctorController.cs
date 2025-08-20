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
    public class DoctorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DoctorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var doctors = _dbContext.Doctors.Include(D => D.Hospital).ToList();
            return View(doctors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(DoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor
                {
                    Name = doctorVM.Name,
                    Qualification = doctorVM.Qualification,
                    Salary = doctorVM.Salary,
                    Hos_id = doctorVM.Hos_id,
                    Hospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == doctorVM.Hos_id)
                };

                _dbContext.Doctors.Add(doctor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name", doctorVM.Hos_id);
            return View(doctorVM);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var doctor = _dbContext.Doctors.Include(d => d.Hospital).FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var doctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            var doctorVM = new DoctorVM
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Qualification = doctor.Qualification,
                Salary = doctor.Salary,
                Hos_id = doctor.Hos_id,
                Hospitals = _dbContext.Hospitals.ToList()
            };
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name", doctor.Hos_id);
            return View(doctorVM);
        }
        [HttpPost]
        public IActionResult Update(DoctorVM doctorVM)
        {
            if (ModelState.IsValid)
            {
                var doctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == doctorVM.Id);
                if (doctor == null)
                {
                    return NotFound();
                }
                doctor.Name = doctorVM.Name;
                doctor.Qualification = doctorVM.Qualification;
                doctor.Salary = doctorVM.Salary;
                doctor.Hos_id = doctorVM.Hos_id;
                doctor.Hospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == doctorVM.Hos_id);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name", doctorVM.Hos_id);
            return View(doctorVM);
        }

        public IActionResult Delete(int id)
        {
            var doctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            TempData["Deletes"] = doctor.Name; 
            _dbContext.Doctors.Remove(doctor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
         
}
