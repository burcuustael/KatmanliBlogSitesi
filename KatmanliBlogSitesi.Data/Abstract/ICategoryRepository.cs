using KatmanliBlogSitesi.Entities;

namespace KatmanliBlogSitesi.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByPostsAsync(int id);
    }
}
