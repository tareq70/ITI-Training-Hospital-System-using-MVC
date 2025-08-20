using ITI_Training_Hospital_System.Models.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.View_Models
{
    public class DoctorVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter doctor name")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Qualification { get; set; }

        [Range(0, 1000000000, ErrorMessage = "Please enter valid salary")]
        public decimal Salary { get; set; }


        [Required]
        public int Hos_id { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; } = new List<Hospital>();
    }
}
