using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MCard40.Model.Entity;

namespace MCard40.Model.Interfaces
{
    public interface IRepository<T, TId> where T : Entity<TId>
    {
        Task<T> Create(T model);
        Task<T> GetByIdAsync(int id);
        T ReadById(TId? id);
        IQueryable<T> Get(Func<T, bool> predicate = null);
        T Delete(T model);
        public T DeleteById(TId id);
        //T Edit(T model);
        public T Update(T entity);
        public bool IsExists(TId id);
        Task SaveAsync();
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
