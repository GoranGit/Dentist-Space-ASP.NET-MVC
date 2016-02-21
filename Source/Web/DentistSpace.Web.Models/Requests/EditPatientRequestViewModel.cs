namespace DentistSpace.Web.Models.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EditPatientRequestViewModel : IMapFrom<PatientRequest>, IHaveCustomMappings
    {
        public string UserId { get; set; }

        public string DentistId { get; set; }

        public string Content { get; set; }

        [Display(Name ="Patient Name")]
        public string PatientName { get; set; }

        [Display(Name ="Accepted patient")]
        public bool IsAccepted { get; set; }

        public int Id { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PatientRequest, EditPatientRequestViewModel>()
                .ForMember(x => x.PatientName, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));
        }
    }
}
