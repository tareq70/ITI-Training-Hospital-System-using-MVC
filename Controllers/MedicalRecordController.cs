using ITI_Training_Hospital_System.Models;
using ITI_Training_Hospital_System.Models.Data;
using ITI_Training_Hospital_System.Models.View_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Training_Hospital_System.Controllers
{
    [Authorize(Roles =ClsRoles.roleAdmin)]
    public class MedicalRecordController : Controller
    {
        private readonly AppDbContext _dbContext;
        public MedicalRecordController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var medicalRecords = _dbContext.MedicalRecords.Include(M => M.Patient).ToList();

            return View(medicalRecords);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Patients = _dbContext.Patients.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(MedicalRecordVM medicalRecordVM)
        {
            if (ModelState.IsValid)
            {
                var medicalRecord = new Models.Entites.MedicalRecord
                {
                    DateOfExamination = medicalRecordVM.DateOfExamination,
                    Problem = medicalRecordVM.Problem,
                    Pat_id = medicalRecordVM.Pat_id,


                    
                };
                _dbContext.MedicalRecords.Add(medicalRecord);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalRecordVM);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var medicalRecord = _dbContext.MedicalRecords
                .Include(m => m.Patient)
                .FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var medicalRecord = _dbContext.MedicalRecords
                .Include(m => m.Patient)
                .FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewBag.Patients = _dbContext.Patients.ToList();
            var medicalRecordVM = new MedicalRecordVM
            {
                Id = medicalRecord.Id,
                DateOfExamination = medicalRecord.DateOfExamination,
                Problem = medicalRecord.Problem,
                Pat_id = medicalRecord.Pat_id
            };
            return View(medicalRecordVM);
        }
        [HttpPost]
        public IActionResult Update(MedicalRecordVM medicalRecordVM)
        {
            if (ModelState.IsValid)
            {
                var medicalRecord = _dbContext.MedicalRecords.Find(medicalRecordVM.Id);
                if (medicalRecord == null)
                {
                    return NotFound();
                }
                medicalRecord.DateOfExamination = medicalRecordVM.DateOfExamination;
                medicalRecord.Problem = medicalRecordVM.Problem;
                medicalRecord.Pat_id = medicalRecordVM.Pat_id;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Patients = _dbContext.Patients.ToList();
            return View(medicalRecordVM);
        }
        public IActionResult Delete(int id)
        {
            var medicalRecord = _dbContext.MedicalRecords.Include(m=>m.Patient).FirstOrDefault(m => m.Id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            TempData["Deletes"] = medicalRecord.Patient.Name;
            _dbContext.MedicalRecords.Remove(medicalRecord);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
