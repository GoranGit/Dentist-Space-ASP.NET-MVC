namespace DentistSpace.Web.Controllers
{
    using System.Web.Mvc;
    using Models.Home;
    using Infrastructure.Mapping;
    using Services.Contracts;
    using System.Linq;
    using System.Collections;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using Services.Web;
    using Infrastructure.Populators;
    using Infrastructure.Constants;

    public class HomeController : BaseController
    {
        private IPostService posts;

        public HomeController(IPostService posts)
        {
            this.posts = posts;
        }

        [PopulateCategories(CashingTime = CacheConstants.ShortCaching)]
        public ActionResult Index()
        {
            var posts = this.posts.GetAllPublic();
            var result = this.Mapper.Map<IEnumerable<PostViewModel>>(posts);

            return this.View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}