namespace DentistSpace.Web.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Constants;
    using Infrastructure.Mapping;
    using Infrastructure.Populators;
    using Models.Home;
    using Models.Posts;
    using Services.Contracts;
    using Services.Web;

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
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}