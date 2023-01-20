using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBlogSitesi.Data.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext _context) : base(_context)
        {
        }

       

        public async Task<Category> GetCategoryByPostsAsync(int id)
        {
            return await context.Categories.Where(k => k.Id == id).AsNoTracking().Include(p => p.Posts).FirstOrDefaultAsync();
        }
    }
}
