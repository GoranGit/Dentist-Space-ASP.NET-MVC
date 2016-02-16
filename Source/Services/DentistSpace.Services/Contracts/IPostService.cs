namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IPostService
    {
        IQueryable<Post> GetLatestPublic(int count, int page);

        IQueryable<Post> GetAllPublic(int count, int page);

        IQueryable<Post> GetAllPublicByCategory(int category, int count, int page);
    }
}
