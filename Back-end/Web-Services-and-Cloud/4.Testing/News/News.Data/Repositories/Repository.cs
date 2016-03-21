using System.Data.Entity;
using System.Linq;

namespace News.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected NewsContext context;
        protected IDbSet<T> set;

        public Repository(NewsContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                set.Attach(entity);
            }

            entry.State = state;
        }
    }
}