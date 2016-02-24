namespace DentistSpace.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Constants;
    using Infrastructure.Populators;
    using Models.Posts;
    using Services.Contracts;

    [Authorize(Roles = Roles.Admin + ", " + Roles.Dentist)]
    public class CommunityController : BaseController
    {
        private IPostService posts;

        public CommunityController(IPostService posts)
        {
            this.posts = posts;
        }

        // GET: Community
        [PopulateCategories(CashingTime = CacheConstants.ShortCaching)]
        public ActionResult Index()
        {
            var posts = this.posts.GetAllPrivate();
            var result = this.Mapper.Map<IEnumerable<PostViewModel>>(posts);
            return this.View(result);
        }
    }
}