namespace DentistSpace.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Dentist : BaseModel<int>
    {
        private ICollection<Patient> patients;
        private ICollection<Post> posts;
        private ICollection<MedicalRecord> medicalRecords;

        public Dentist()
        {
            this.patients = new HashSet<Patient>();
            this.posts = new HashSet<Post>();
            this.medicalRecords = new HashSet<MedicalRecord>();
        }

        public virtual User User { get; set; }

        public bool IsAccepted { get; set; }

        public virtual ICollection<Patient> Patients
        {
            get
            {
                return this.patients;
            }

            set
            {
                this.patients = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
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
