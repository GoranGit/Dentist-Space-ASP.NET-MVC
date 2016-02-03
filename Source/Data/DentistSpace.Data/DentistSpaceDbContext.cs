namespace DentistSpace.Data
{
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DentistSpaceDbContext : IdentityDbContext<User>, IDentistSpaceDbContext
    {
        public DentistSpaceDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {   
        }

        public static DentistSpaceDbContext Create()
        {
            return new DentistSpaceDbContext();
        }
    }
}
