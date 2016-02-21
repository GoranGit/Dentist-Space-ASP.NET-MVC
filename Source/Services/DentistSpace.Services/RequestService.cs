namespace DentistSpace.Services
{
    using System;
    using Data;
    using DentistSpace.Data.Models;
    using DentistSpace.Services.Contracts;

    public class RequestService : IRequestService
    {
        private IDbRepository<PatientRequest, int> requests;

        public RequestService(IDbRepository<PatientRequest, int> requests)
        {
            this.requests = requests;
        }

        public void AddPatientRequest(PatientRequest request)
        {
            this.requests.Add(request);
            this.requests.Save();
        }
    }
}
