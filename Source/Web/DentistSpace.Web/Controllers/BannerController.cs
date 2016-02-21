namespace DentistSpace.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Models.Home;
    using Services.Contracts;

    public class BannerController : BaseController
    {
        private IBannerService banners;

        public BannerController(IBannerService banners)
        {
            this.banners = banners;
        }

        // GET: Banner
        [ChildActionOnly]
        public ActionResult GetMainBanner()
        {
            var banner = this.banners.GetMainBanner();
            var result = this.Mapper.Map<BannerViewModel>(banner);
            if (result == null)
            {
                return this.Content("Main banner!");
            }

            return this.PartialView("_MainBannerPartial", result);
        }

        [ChildActionOnly]
        public ActionResult GetLeftBanner()
        {
            var banner = this.banners.GetLeftBanner();
            var result = this.Mapper.Map<BannerViewModel>(banner);
            if (result == null)
            {
                return this.Content("Left banner!");
            }
            return this.PartialView("_LeftBannerPartial", result);
        }

        [ChildActionOnly]
        public ActionResult GetBottomBanner()
        {
            var banner = this.banners.GetBottomBanner();
            var result = this.Mapper.Map<BannerViewModel>(banner);
            if (result == null)
            {
                return this.Content("Bottom banner!");
            }
            return this.PartialView("_BottomBannerPartial", result);
        }
    }
}