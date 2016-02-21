namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface IDentistService
    {
        IQueryable<Dentist> GetDentists(string filter);
    }
}
