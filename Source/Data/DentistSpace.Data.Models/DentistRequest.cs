namespace DentistSpace.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using DentistSpace.Data.Common.Models;

    public class DentistRequest : BaseModel<int>
    {
        public DentistRequest()
        {
            this.FileName = Guid.NewGuid();
        }

        [Required]
        public string UserId { get; set; }

        public string AcceptedByAdminId { get; set; }

        public bool IsAccepted { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(300)]
        public string Content { get; set; }

        public Guid FileName { get; set; }

        [Required]
        public string Extension { get; set; }

        public virtual User User { get; set; }
    }
}
