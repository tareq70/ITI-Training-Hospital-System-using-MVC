using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Training_Hospital_System.Models.Entites
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }

        public decimal Salary { get; set; }

        // Foreign Key
        [ForeignKey("Hospital")]
        public int Hos_id { get; set; }
        public Hospital Hospital { get; set; }

    }
}
