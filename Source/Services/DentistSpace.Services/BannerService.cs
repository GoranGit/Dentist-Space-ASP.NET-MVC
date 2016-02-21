namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data.Common;
    using DentistSpace.Data;
    using DentistSpace.Data.Models;
    using DentistSpace.Services.Contracts;

    public class BannerService : IBannerService
    {
        private IDbRepository<Banner, int> banners;

        public BannerService(IDbRepository<Banner, int> banners)
        {
            this.banners = banners;
        }

        public Banner GetBottomBanner()
        {
            var banner = this.banners
                .All()
                .Where(x => x.Type == BannerType.BottomBanner && x.TimesToShow > 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();
            if (banner != null && banner.TimesToShow > 0)
            {
                banner.TimesToShow--;
                this.banners.Update(banner);
                this.banners.Save();
            }

            return banner;
        }

        public Banner GetLeftBanner()
        {
            var banner = this.banners
               .All()
               .Where(x => x.Type == BannerType.LeftSideBanner && x.TimesToShow > 0)
               .OrderBy(x => Guid.NewGuid())
               .FirstOrDefault();

            if (banner != null && banner.TimesToShow > 0)
            {
                banner.TimesToShow--;
                this.banners.Update(banner);
                this.banners.Save();
            }

            return banner;
        }

        public Banner GetMainBanner()
        {
            var banner = this.banners
               .All()
               .Where(x => x.Type == BannerType.TopBanner && x.TimesToShow > 0)
               .OrderBy(x => Guid.NewGuid())
               .FirstOrDefault();

            if (banner != null && banner.TimesToShow > 0)
            {
                banner.TimesToShow--;
                this.banners.Update(banner);
                this.banners.Save();
            }

            return banner;
        }

        public Banner GetRightBanner()
        {
            var banner = this.banners
                .All()
                .Where(x => x.Type == BannerType.RightSideBanner && x.TimesToShow > 0)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            if (banner != null && banner.TimesToShow > 0)
            {
                banner.TimesToShow--;
                this.banners.Update(banner);
                this.banners.Save();
            }

            return banner;
        }
    }
}
