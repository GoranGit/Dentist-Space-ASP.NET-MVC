namespace DentistSpace.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Home;
    using Models.Posts;
    using Services.Contracts;

    public class PostsController : BaseController
    {

        private IPostService posts;

        public PostsController(IPostService posts)
        {
            this.posts = posts;
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPostsByCategoryId(int id)
        {
            var posts = this.posts.GetAllPublicByCategory(id);
            var result = this.Mapper.Map<IEnumerable<PostViewModel>>(posts);
            return this.PartialView("_PostsPartial", result);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var post = this.posts.GetPostDetails(id);
            var result = this.Mapper.Map<PostDetailsViewModel>(post);
            return this.View(result);
        }
    }
}