using KatmanliBlogSitesi.Data;
using KatmanliBlogSitesi.Data.Concrete;
using KatmanliBlogSitesi.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBlogSitesi.Service.Concrete
{
    public class PostService : PostRepository, IPostService
    {
        public PostService(DatabaseContext _context) : base(_context)
        {

        }
    }
}
