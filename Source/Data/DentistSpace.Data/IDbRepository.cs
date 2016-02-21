namespace DentistSpace.Data
{
    using System.Linq;
    using DentistSpace.Data.Common.Models;

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Update(T entity);
      
        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
