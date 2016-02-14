namespace DentistSpace.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using DentistSpace.Data.Common.Models;

    public class MedicalRecord : BaseModel<int>
    {
        private ICollection<Image> images;

        public MedicalRecord()
        {
            this.images = new HashSet<Image>();
        }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string DentistId { get; set; }

        public virtual Dentist Dentist { get; set; }
    }
}