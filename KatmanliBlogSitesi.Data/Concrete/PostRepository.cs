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

        public Task<Post> GetPostByCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
