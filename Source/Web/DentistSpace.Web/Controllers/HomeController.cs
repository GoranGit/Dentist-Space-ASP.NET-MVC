namespace DentistSpace.Web.Controllers
{
    using System;
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

        public ActionResult Index(int id = 1)
        {
            var search = this.Request.QueryString["search"];
            var page = id;
            var allItemsCount = this.posts.PublicPostsCount();

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)9);
            var skip = (page - 1) * 9;

            List<PostViewModel> posts;

            if (search != null)
            {
                posts = this.Mapper.Map<IEnumerable<PostViewModel>>(this.posts
                .GetAllPublic()
                .Where(x => x.Title.Contains(search))).ToList<PostViewModel>();
            }
            else
            {
                posts = this.Mapper.Map<IEnumerable<PostViewModel>>(this.posts
               .GetAllPublic(9, page)).ToList<PostViewModel>();
            }

            var resultModel = new IndexPageableModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Posts = posts
            };

            return this.View(resultModel);
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