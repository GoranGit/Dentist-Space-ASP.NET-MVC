namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;

    public class PostService : IPostService
    {
        private IDbRepository<Post> posts;

        public PostService(IDbRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> GetAllPublic(int count = 6, int page = 1)
        {
            return this.posts
                .All()
                .Where(x => x.IsPublic)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * count)
                .Take(count);
        }

        public IQueryable<Post> GetAllPublicByCategory(int categoryId, int count, int page)
        {
            return this.posts
                .All()
                .Where(x => (x.CategoryId == categoryId) && x.IsPublic)
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * count)
                .Take(count);
        }

        public IQueryable<Post> GetLatestPublic(int count, int page)
        {
            return this.posts
                 .All()
                 .Where(x => x.IsPublic)
                 .OrderByDescending(x => x.CreatedOn)
                 .Skip((page - 1) * count)
                 .Take(count);
        }
    }
}
