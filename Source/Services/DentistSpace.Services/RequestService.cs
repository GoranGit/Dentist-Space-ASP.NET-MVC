namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Common;
    using Data;
    using DentistSpace.Data.Models;
    using DentistSpace.Services.Contracts;

    public class RequestService : IRequestService
    {
        private IDbRepository<PatientRequest, int> requests;
        private IRoleService roles;

        public RequestService(IDbRepository<PatientRequest, int> requests, IRoleService roles)
        {
            this.requests = requests;
            this.roles = roles;
        }

        public void AddPatientRequest(PatientRequest request)
        {
            this.requests.Add(request);
            this.requests.Save();
        }

        public IQueryable<PatientRequest> GetPatientsRequestsForDentist(string dentistId)
        {
            return this.requests
                   .All()
                   .Where(x => x.DentistId == dentistId)
                   .OrderByDescending(x => x.CreatedOn);
        }

        public void AcceptPatientRequest(PatientRequest request)
        {
            if (request.IsAccepted)
            {
                this.roles.ChangeRoleFor(request.UserId, Roles.Patient);
            }
            else
            {
                this.roles.ChangeRoleFor(request.UserId, Roles.User);
            }

            this.requests.Update(request);
            this.requests.Save();
        }

        public PatientRequest GetById(int id)
        {
            return this.requests.GetById(id);
        }
    }
}
