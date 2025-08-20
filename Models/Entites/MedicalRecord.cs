using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.Entites
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime DateOfExamination { get; set; }
        public string Problem { get; set; }

        // Foreign Key
        [ForeignKey("Patient")]
        public int Pat_id { get; set; }
        public Patient Patient { get; set; }
    }
}
