﻿namespace DentistSpace.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using DentistSpace.Data.Common.Models;

    public class PatientRequest : BaseModel<int>
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Dentist")]
        public string DentistId { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsAccepted { get; set; }

        public virtual User User { get; set; }

        public virtual Dentist Dentist { get; set; }
    }
}
