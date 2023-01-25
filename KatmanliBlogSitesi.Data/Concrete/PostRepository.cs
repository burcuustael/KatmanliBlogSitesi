using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace KatmanliBlogSitesi.Data.Concrete
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DatabaseContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Post>> GetAllPostsByCategoriesAsync()
        {
            return await context.Posts.Include(c=>c.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetPostByCategoriesAsync(int id)
        {
            return await context.Posts.Include(c => c.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
