using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, IEntity
    {

        private readonly AsupContext asupContext;
        protected readonly DbSet<T> dbSet;
        public Repository()
        {
            asupContext = new AsupContext();
            dbSet = this.asupContext.Set<T>();
        }

        public async Task SaveChangesAsync()
        {
            await asupContext.SaveChangesAsync();
        }

        public async Task<Guid> Add(T entity)
        {
            var id = Guid.NewGuid();
            entity.Id = id;
            var r = await dbSet.AddAsync(entity);
            return entity.Id;
        }

        public async Task<T> Delete(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
            return entity;
        }

        public async Task<T> Get(Guid id)
        {
            var result = await dbSet.FindAsync(id);
            return result;
        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            
            return await dbSet.AsQueryable().ToListAsync();
        }

        public void Update(T entity)
        {
            this.dbSet.Update(entity);
        }

        void IDisposable.Dispose()
        {
            asupContext.Dispose();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return this.dbSet.AsQueryable();
        }
    }
}
