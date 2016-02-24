namespace DentistSpace.Services
{
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;

    public class MedicalRecordService : IMedicalRecordService
    {
        private IDbRepository<MedicalRecord, int> medicalRecords;

        public MedicalRecordService(IDbRepository<MedicalRecord, int> medicalRecords)
        {
            this.medicalRecords = medicalRecords;
        }

        public IQueryable<MedicalRecord> GetRecordsForPatientByDentist(string patientId, string dentistId)
        {
            return this.medicalRecords
                .All()
                .Where(x => x.DentistId == dentistId && x.PatientId == patientId);
        }

        public void AddNewMedicalRecord(MedicalRecord record)
        {
            this.medicalRecords.Add(record);
            this.medicalRecords.Save();
        }
    }
}
