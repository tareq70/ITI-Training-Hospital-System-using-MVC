using System.Diagnostics;
using ITI_Training_Hospital_System.Models;
using ITI_Training_Hospital_System.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Training_Hospital_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            ViewBag.HospitalsCount = _dbContext.Hospitals.Count();
            ViewBag.PatientsCount = _dbContext.Patients.Count();
            ViewBag.DoctorsCount = _dbContext.Doctors.Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
