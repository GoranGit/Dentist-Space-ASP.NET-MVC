namespace DentistSpace.Web.Models.Posts
{
    using System;
    using AutoMapper;
    using BaseModels;
    using DentistSpace.Data.Models;
    using Infrastructure.Mapping;

    public class PostDetailsViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        private string imageUrl;

        private string userAvatar;

        public string Title { get; set; }

        //TODO HTML Sanitizer
        public string Content { get; set; }

        public string UserName { get; set; }

        public string UserDetailsLink { get; set; }

        public string CreatedOn { get; set; }

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

        public string UserAvatar
        {
            get
            {
                return this.userAvatar;
            }

            set
            {
                if (value == null)
                {
                    this.userAvatar = "http://pickaface.net/avatar/Opi51c74d0125fd4.png";
                }
                else
                {
                    this.userAvatar = value;
                }
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostDetailsViewModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.Image))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Dentist.User.FirstName + " " + x.Dentist.User.LastName))
                .ForMember(x => x.UserDetailsLink, opt => opt.MapFrom(x => "/Dentists/Details/" + x.DentistId))
                .ForMember(x => x.UserAvatar, opt => opt.MapFrom(x => x.Dentist.User.Avatar))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn.ToString("MMMM MM,yyyy")));
        }
    }
}
