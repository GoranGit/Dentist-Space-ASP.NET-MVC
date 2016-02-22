namespace DentistSpace.Web.Areas.Dentists.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.ModelFilters;
    using Infrastructure.Populators;
    using Microsoft.AspNet.Identity;
    using Models.Posts;
    using Services.Contracts;
    using Web.Controllers;

    [Authorize(Roles = Roles.Dentist)]
    public class PostsController : BaseController
    {
        private IPostService posts;

        public PostsController(IPostService posts)
        {
            this.posts = posts;
        }

        // GET: Dentists/Posts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [PopulateCategories]
        public ActionResult Create()
        {
            this.ViewBag.Title = "Create new post";
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PopulateCategories]
        [ValidateModelState]
        public ActionResult Create(InputPostViewModel post)
        {
            var entity = this.Mapper.Map<InputPostViewModel, Post>(post);
            entity.DentistId = this.User.Identity.GetUserId();
            this.posts.AddNewPost(entity);
            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }
    }
}