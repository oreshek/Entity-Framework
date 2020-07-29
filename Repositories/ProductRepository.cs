using Entity_Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public async Task<IEnumerable<Product>> GetAllWithMaterials()
        {
            return await dbSet.Include(p => p.ProductMaterials)
                .ThenInclude(m => m.Material)
                .ToListAsync();
        }
    }
}
