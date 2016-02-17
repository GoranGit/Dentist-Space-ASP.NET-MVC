namespace DentistSpace.Data.Models
{
    using DentistSpace.Data.Common;
    using Common.Models;

    public class Banner : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        public string CompanyUrl { get; set; }

        public int TimesToShow { get; set; }

        public BannerType Type { get; set; }
    }
}
