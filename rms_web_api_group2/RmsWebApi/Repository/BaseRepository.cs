using Microsoft.EntityFrameworkCore;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;
using RmsWebApi.RMS_DB;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RmsWebApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RMSContext context;
        protected readonly DbSet<T> entitySet;

        public BaseRepository(RMSContext context)
        {
            this.context = context;
            
            this.entitySet = this.context.Set<T>();
        }

        public List<T> SelectAll()
        {
            return entitySet.ToList();
        }
        public void Create(T entity)
        {
            this.entitySet.Add(entity);
            this.context.SaveChanges();
        }
        public void Update(T entity)
        {
            this.entitySet.Update(entity);
            this.context.SaveChanges();
        }
        public void Delete(T entity)
        {
            this.entitySet.Remove(entity);
            this.context.SaveChanges();
        }

    }

}
