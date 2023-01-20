using KatmanliBlogSitesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBlogSitesi.Data.Abstract
{
    public interface IPostRepository: IRepository<Post>

    {
        Task<IEnumerable<Post>> GetAllPostsByCategoriesAsync();
        Task<Post> GetPostByCategoriesAsync();
    }
}
