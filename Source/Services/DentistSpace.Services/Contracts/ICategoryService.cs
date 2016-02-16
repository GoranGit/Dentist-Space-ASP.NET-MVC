namespace DentistSpace.Services.Contracts
{
    using System.Linq;
    using DentistSpace.Data.Models;

    public interface ICategoryService
    {
        void Add(Category category);

        IQueryable<Category> GetAll();
    }
}
