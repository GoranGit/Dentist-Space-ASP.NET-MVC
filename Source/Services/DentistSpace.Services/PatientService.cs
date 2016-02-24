namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;

    public class PatientService : IPatientService
    {
        private IDbRepository<Patient, string> patients;

        public PatientService(IDbRepository<Patient, string> patients)
        {
            this.patients = patients;
        }

        public Patient CreateNewPatient(string userId, Dentist dentist)
        {
            var p = this.patients.GetById(userId);
            if (p == null)
            {
                Patient patient = new Patient()
                {
                    Id = userId
                };

                patient.Dentists.Add(dentist);

                this.patients.Add(patient);
                this.patients.Save();
                return patient;
            }else
            {
                p.Dentists.Add(dentist);
                this.patients.Save();
            }

            return p;
        }
    }
}
