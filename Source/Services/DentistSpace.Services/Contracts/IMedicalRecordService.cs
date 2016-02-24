namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface IMedicalRecordService
    {
        IQueryable<MedicalRecord> GetRecordsForPatientByDentist(string patientId, string dentistId);

        void AddNewMedicalRecord(MedicalRecord record);
    }
}
