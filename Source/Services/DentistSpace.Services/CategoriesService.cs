namespace DentistSpace.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using DentistSpace.Services.Contracts;

    public class CategoriesService : ICategoryService
    {
        private IDbRepository<Category, int> categories;

        public CategoriesService(IDbRepository<Category,int> categories)
        {
            this.categories = categories;
        }

        public void Add(Category category)
        {
            this.categories.Add(category);
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }
    }
}
