namespace DentistSpace.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Patient : BaseModel<string>
    {
        private ICollection<Dentist> dentists;
        private ICollection<MedicalRecord> medicalRecords;

        public Patient()
        {
            this.dentists = new HashSet<Dentist>();
            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        public bool IsAccepted { get; set; }

        [ForeignKey("User")]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public virtual User User { get; set; }

        public virtual ICollection<Dentist> Dentists
        {
            get
            {
                return this.dentists;
            }

            set
            {
                this.dentists = value;
            }
        }

        public virtual ICollection<MedicalRecord> MedicalRecords
        {
            get
            {
                return this.medicalRecords;
            }

            set
            {
                this.medicalRecords = value;
            }
        }
    }
}
