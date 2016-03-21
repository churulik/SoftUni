using System.Linq;

namespace News.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}