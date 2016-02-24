namespace DentistSpace.Web.Models.MedicalRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditPatientMedicalRecordsViewModel : IMapFrom<Patient>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<MedicalRecordViewModel> MedicalRecords { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Patient, EditPatientMedicalRecordsViewModel>()
                .ForMember(x => x.MedicalRecords, opt => opt.MapFrom(x => x.MedicalRecords.ToList()))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName));
        }
    }
}
