using Nh.Data.Entities;
using System.Collections.Generic;

namespace Nh.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Get(long id);
        void Delete(T entity);
        void Update(T entity);
    }
}
