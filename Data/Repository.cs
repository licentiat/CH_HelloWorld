using Microsoft.EntityFrameworkCore;
using Nh.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nh.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private const string NullErrorMessage = "Null entity is not acceptable.";
        private readonly NhContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(NhContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), NullErrorMessage);
            }
            entities.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), NullErrorMessage);
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), NullErrorMessage);
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
