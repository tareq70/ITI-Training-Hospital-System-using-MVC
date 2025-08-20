using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.Entites
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public string Address { get; set; }

        // Foreign Key for Hospital
        [ForeignKey("Hospital")]
        public int Hospital_id { get; set; }

        public Hospital Hospital { get; set; }

        // Navigation Property for Medical Records
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
