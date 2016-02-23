namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IPostService
    {
        void AddNewPost(Post post);

        IQueryable<Post> GetLatestPublic(int count = 9, int page = 1);

        IQueryable<Post> GetAllPublic(int count = 6, int page = 1);

        IQueryable<Post> GetAllPublicByCategory(int category, int count = 9, int page = 1);

        IQueryable<Post> GetAllPrivateByCategory(int category, int count = 9, int page = 1);

        Post GetPostDetails(string urlId);

        IQueryable<Post> GetAllPrivate(int count = 9, int page = 1);
    }
}
