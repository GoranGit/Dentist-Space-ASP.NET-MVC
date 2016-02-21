namespace DentistSpace.Services.Contracts
{
    using DentistSpace.Data.Models;

    public interface IRequestService
    {
        void AddPatientRequest(PatientRequest request);
    }
}
