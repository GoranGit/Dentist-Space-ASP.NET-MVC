namespace DentistSpace.Web.Models.Requests
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class InputPatientRequestViewModel : IMapTo<PatientRequest>
    {
        [Required]
        public string DentistId { get; set; }

        [Required]
        [MinLength(10), MaxLength(300)]
        public string Content { get; set; }
    }
}
