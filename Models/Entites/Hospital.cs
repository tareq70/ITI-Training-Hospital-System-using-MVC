using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ITI_Training_Hospital_System.Models.Entites
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }


        // Navigation Property - One Hospital has many Patients
        public ICollection<Patient> Patients { get; set; }

        // Navigation Property - One Hospital has many Doctors
        public ICollection<Doctor> Doctors { get; set; }
    }
}
