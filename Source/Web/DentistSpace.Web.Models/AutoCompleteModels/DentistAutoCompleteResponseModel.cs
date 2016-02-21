namespace DentistSpace.Web.Models.AutoCompleteModels
{
    using System;
    using AutoMapper;
    using DentistSpace.Data.Models;
    using DentistSpace.Web.Infrastructure.Mapping;

    public class DentistAutoCompleteResponseModel : IMapFrom<Dentist>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Dentist, DentistAutoCompleteResponseModel>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName));
        }
    }
}
