namespace DentistSpace.Web.Models.Home
{
    using DentistSpace.Data.Models;
    using DentistSpace.Web.Infrastructure.Mapping;

    public class BannerViewModel : IMapFrom<Banner>
    {
        public string ImageUrl { get; set; }

        public string CompanyUrl { get; set; }
    }
}
