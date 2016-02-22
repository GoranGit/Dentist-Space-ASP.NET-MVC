namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;

    public class DentistService : IDentistService
    {
        private IDbRepository<Dentist, string> dentists;

        public DentistService(IDbRepository<Dentist, string> dentists)
        {
            this.dentists = dentists;
        }

        public Dentist GetDentistById(string dentistId)
        {
            return this.dentists.GetById(dentistId);
        }

        public IQueryable<Dentist> GetDentists(string filter)
        {
            string[] fullName = filter.Split(' ');
            string firstName = fullName[0];
            string lastName = null;
            if (fullName.Length > 1)
            {
                lastName = fullName[1];
            }

            return this.dentists
                 .All()
                 .Where(x => (x.User.FirstName.Contains(firstName) && 
                 (lastName != null ? x.User.LastName.Contains(lastName) : true)));
        }
    }
}
