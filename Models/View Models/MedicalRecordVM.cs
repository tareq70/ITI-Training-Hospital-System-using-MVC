using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.View_Models
{
    public class MedicalRecordVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter examination date")]
        public DateTime DateOfExamination { get; set; }

        [StringLength(200)]
        public string Problem { get; set; }

        [Required]
        public int Pat_id { get; set; }
    }
}
