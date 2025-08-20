using System.ComponentModel.DataAnnotations;

namespace ITI_Training_Hospital_System.Models.View_Models
{
    public class HospitalVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter hospital name")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string City { get; set; }
        
    }
}
