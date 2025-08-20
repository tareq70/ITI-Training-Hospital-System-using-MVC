using ITI_Training_Hospital_System.Models.Entites;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.View_Models
{
    public class PatientVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter patient name")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Diagnosis { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        public int Hos_id { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; } = new List<Hospital>();

    }
}
