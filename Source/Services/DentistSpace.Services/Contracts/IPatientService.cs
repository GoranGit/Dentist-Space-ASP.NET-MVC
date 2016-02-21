namespace DentistSpace.Services.Contracts
{
    using DentistSpace.Data.Models;

    public interface IPatientService
    {
        Patient CreateNewPatient(string userId, Dentist dentist);
    }
}
