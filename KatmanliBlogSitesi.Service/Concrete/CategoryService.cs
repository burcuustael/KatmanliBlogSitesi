using KatmanliBlogSitesi.Data;
using KatmanliBlogSitesi.Data.Concrete;
using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KatmanliBlogSitesi.Service.Concrete
{
    public class CategoryService : CategoryRepository, ICategoryService
    {
        public CategoryService(DatabaseContext _context) : base(_context)
        {
        }

        
        public async Task<Category> GetCategoryByPostsAsync(int id)
        {
            return await context.Categories.Where(k => k.Id == id).AsNoTracking().Include(p => p.Posts).FirstOrDefaultAsync();
        }
    }
}
