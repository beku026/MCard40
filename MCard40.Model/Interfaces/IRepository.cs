using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Model.Interfaces
{
    public interface IRepository<T, TId> where T : class,IEntity<TId>
    {
        Task<T> Create(T model);
        public List<T> ReadAll();
        Task<T> GetByIdAsync(int id);
        T ReadById(TId? id);
        IQueryable<T> Get(Func<T, bool> predicate = null);
        T Delete(T model);
        public T DeleteById(TId id);
        public T Update(T entity);
        public bool IsExists(TId id);
        Task SaveAsync();
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
