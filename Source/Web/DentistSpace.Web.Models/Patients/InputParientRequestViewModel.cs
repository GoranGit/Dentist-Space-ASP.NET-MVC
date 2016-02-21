namespace DentistSpace.Web.Models.Patients
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class InputParientRequestViewModel : IMapTo<PatientRequest>
    {
        [Required]
        public string DoctorId { get; set; }

        [Required]
        [MinLength(10), MaxLength(300)]
        public string Content { get; set; }
    }
}
