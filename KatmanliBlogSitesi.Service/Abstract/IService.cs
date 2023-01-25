using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBlogSitesi.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
       
    }
}
