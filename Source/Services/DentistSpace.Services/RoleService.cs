namespace DentistSpace.Services.UserServices
{
    using Contracts;
    using DentistSpace.Data;
    using DentistSpace.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class RoleService : IRoleService
    {
        private UserManager<User> userManager;

        private DentistSpaceDbContext context;

        public RoleService()
        {
            //TODO: Get out somehow this dependencies.
            this.context = new DentistSpaceDbContext();
            this.userManager = new UserManager<User>(new UserStore<User>(context));
        }

        public void ChangeRoleFor(string userId, string role)
        {
            this.userManager.AddToRole(userId, role);
        }
    }
}
