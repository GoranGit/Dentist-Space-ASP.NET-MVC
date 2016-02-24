namespace DentistSpace.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DentistSpace.Data.Common.Models;

    public class MedicalRecord : BaseModel<int>
    {
        public MedicalRecord()
        {
            this.FileName = Guid.NewGuid();
        }

        public Guid FileName { get; set; }

        [Required]
        public string OriginalName { get; set; }

        [Required]
        public string Extension { get; set; }

        [Required]
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string DentistId { get; set; }

        public virtual Dentist Dentist { get; set; }
    }
}