namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface IPatientService
    {
        Patient CreateNewPatient(string userId, Dentist dentist);
    }
}
