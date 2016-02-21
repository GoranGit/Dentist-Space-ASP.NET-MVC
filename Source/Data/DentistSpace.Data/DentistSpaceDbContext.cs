namespace DentistSpace.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

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

        public virtual IDbSet<PatientRequest> PatientRequests { get; set; }

        public static DentistSpaceDbContext Create()
        {
            return new DentistSpaceDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
