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

    public class HomeController : BaseController
    {
        private IPostService posts;

        public HomeController(IPostService posts)
        {
            this.posts = posts;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Home";

            var posts = this.posts.GetAllPublic(10, 1);
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