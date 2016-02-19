namespace DentistSpace.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.Home;
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
            var posts = this.posts.GetAllPublic();
            var result = this.Mapper.Map<IEnumerable<PostViewModel>>(posts);

            return this.PartialView("_PostsPartial", result);
        }
    }
}