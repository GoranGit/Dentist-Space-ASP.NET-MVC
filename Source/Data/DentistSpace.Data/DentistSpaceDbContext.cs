namespace DentistSpace.Data
{
    using System.Data.Entity;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DentistSpaceDbContext : IdentityDbContext<User>, IDentistSpaceDbContext
    {
        public DentistSpaceDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Dentist> Dentists { get; set; }

        public virtual IDbSet<Admin> Admins { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Patient> Patients { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Banner> Banners { get; set; }

        public virtual IDbSet<MedicalRecord> MedicalRecords { get; set; }

        public static DentistSpaceDbContext Create()
        {
            return new DentistSpaceDbContext();
        }
    }
}
