using Microsoft.EntityFrameworkCore;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RMSContext context;
        protected DbSet<T> entitySet;

        public BaseRepository(RMSContext context)
        {
            this.context = context;
            this.entitySet = this.context.Set<T>();
        }

        public void Delete(T entity)
        {
            this.entitySet.Remove(entity);
            this.context.SaveChanges();
        }

        public List<T> SelectAll()
        {
            return this.entitySet.ToList();
        }
        
        public void Insert(T obj)
        {
            this.entitySet.Add(obj);
            this.context.SaveChanges();
        }

        public void Update(T obj)
        {
            this.entitySet.Update(obj);
            this.context.SaveChanges();
        }
    }
    
}
