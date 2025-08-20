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
    public class PatientController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PatientController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var patients = _dbContext.Patients.Include(p => p.Hospital).ToList();
            return View(patients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Hospitals = _dbContext.Hospitals.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PatientVM patientViewModel)
        {
            if (ModelState.IsValid)
            {
                var patient = new Models.Entites.Patient
                {
                    Name = patientViewModel.Name,
                    Diagnosis = patientViewModel.Diagnosis,
                    Address = patientViewModel.Address,
                    Hospital_id = patientViewModel.Hos_id,
                    Hospital = _dbContext.Hospitals.FirstOrDefault(h => h.Id == patientViewModel.Hos_id)

                };
                _dbContext.Patients.Add(patient);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name");
            return View(patientViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var Pt = _dbContext.Patients.FirstOrDefault(p => p.Id == id);
            if (Pt == null)
            {
                return NotFound("Not Found: 404");
            }
            var vm = new PatientVM
            {
                Id = Pt.Id,
                Name = Pt.Name,
                Diagnosis = Pt.Diagnosis,
                Address = Pt.Address,
                Hos_id = Pt.Hospital_id
            };
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name", Pt.Hospital_id);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Update(PatientVM patientvm)
        {

            if (ModelState.IsValid)
            {
                var pt = _dbContext.Patients.FirstOrDefault(p => p.Id == patientvm.Id);

                if (pt != null)
                {
                    pt.Name = patientvm.Name;
                    pt.Address = patientvm.Address;
                    pt.Diagnosis = patientvm.Diagnosis;
                    pt.Hospital_id = patientvm.Hos_id;

                }
                _dbContext.SaveChanges();

            }
            ViewBag.Hospitals = new SelectList(_dbContext.Hospitals.ToList(), "Id", "Name", patientvm.Hos_id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var patient = _dbContext.Patients.Include(N => N.Hospital).FirstOrDefault(s => s.Id == id);
            if (patient == null)
            {
                return NotFound("Not Found: 404");
            }
            ViewBag.Pit = patient;
            return View(patient);
        }


        public IActionResult Delete(int id)
        {
            var patient = _dbContext.Patients.FirstOrDefault(s => s.Id == id);
            if (patient == null)
            {
                return NotFound("Not Found: 404");
            }
            TempData["Deletes"] = patient.Name;
            _dbContext.Patients.Remove(patient);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
