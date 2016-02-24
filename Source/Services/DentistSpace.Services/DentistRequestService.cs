namespace DentistSpace.Services
{
    using System;
    using Data;
    using DentistSpace.Data.Models;
    using DentistSpace.Services.Contracts;

    public class DentistRequestService : IDentistRequestService
    {
        private IDbRepository<DentistRequest, int> dentistRequests;

        public DentistRequestService(IDbRepository<DentistRequest, int> dentistRequests)
        {
            this.dentistRequests = dentistRequests;
        }

        public void AddRequest(DentistRequest request)
        {
            this.dentistRequests.Add(request);
            this.dentistRequests.Save();
        }
    }
}
