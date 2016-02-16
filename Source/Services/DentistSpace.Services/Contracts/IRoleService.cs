namespace DentistSpace.Services.Contracts
{
    using DentistSpace.Data.Models;

    public interface IRoleService
    {
        void ChangeRoleFor(User user, string role);
    }
}
