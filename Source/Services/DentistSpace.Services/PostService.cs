namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;
    using Web;

    public class PostService : IPostService
    {
        private IIdentifierProvider identifier;
        private IDbRepository<Post, int> posts;

        public PostService(IDbRepository<Post, int> posts, IIdentifierProvider identifier)
        {
            this.posts = posts;
            this.identifier = identifier;
        }

        public void AddNewPost(Post post)
        {
            this.posts.Add(post);
            this.posts.Save();
        }

        public IQueryable<Post> GetAllPrivate(int count = 9, int page = 1)
        {
            return this.posts
               .All()
               .Where(x => !x.IsPublic)
               .OrderByDescending(x => x.CreatedOn)
               .Skip((page - 1) * count)
               .Take(count);
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

        public int PublicPostsCount()
        {
            return this.posts.All().Where(x => x.IsPublic).Count();
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

        public IQueryable<Post> GetAllPrivateByCategory(int categoryId, int count, int page)
        {
            return this.posts
                .All()
                .Where(x => (x.CategoryId == categoryId) && !x.IsPublic)
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

        public Post GetPostDetails(string urlId)
        {
            int id = this.identifier.DecodeId(urlId);
            return this.posts
                 .GetById(id);
        }
    }
}
