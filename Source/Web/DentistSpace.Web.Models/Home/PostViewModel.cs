namespace DentistSpace.Web.Models.Home
{
    using System;
    using AutoMapper;
    using BaseModels;
    using Data.Models;
    using DentistSpace.Web.Infrastructure.Mapping;

    public class PostViewModel : IdentifierBaseModel, IMapFrom<Post>, IHaveCustomMappings
    {
        private string imageUrl;

        public string Url { get; set; }

        public string Title { get; set; }

        //TODO HTML Sanitizer
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }

            set
            {
                if (value == null)
                {
                    this.imageUrl = "http://pre09.deviantart.net/1d29/th/pre/f/2013/068/6/4/tooth_by_keketz-d5xhsi4.png";
                }
                else
                {
                    this.imageUrl = value;
                }
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Url, opt => opt.MapFrom(x => "/Post/Details/" + this.identifierProvider.EncodeId(x.Id)))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.Image));
        }
    }
}
