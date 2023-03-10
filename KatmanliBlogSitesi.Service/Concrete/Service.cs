using KatmanliBlogSitesi.Data.Concrete;
using KatmanliBlogSitesi.Data;
using KatmanliBlogSitesi.Entities;
using KatmanliBlogSitesi.Service.Abstract;

namespace KatmanliBlogSitesi.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {

        }

    }
}
