using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        Task<T> Get(Guid id);
        Task<Guid> Add(T entity);
        void Update(T entity);
        Task<T> Delete(Guid id);
        Task SaveChangesAsync();

    }


}
