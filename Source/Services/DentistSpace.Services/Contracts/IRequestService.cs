namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface IRequestService
    {
        void AddPatientRequest(PatientRequest request);

        IQueryable<PatientRequest> GetPatientsRequestsForDentist(string dentistId);

        void AcceptPatientRequest(PatientRequest request);

        PatientRequest GetById(int id);
    }
}
