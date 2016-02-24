namespace DentistSpace.Web.Models.MedicalRecords
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class MedicalRecordViewModel : IMapFrom<MedicalRecord>
    {
        public int Id { get; set; }

        public string OriginalName { get; set; }

        public string PatientId { get; set; }

        public string DentistId { get; set; }
    }
}
