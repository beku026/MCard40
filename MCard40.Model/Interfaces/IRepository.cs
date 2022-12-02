using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Model.Interfaces
{
    public interface IRepository<T> where T : class, IEntity<int>
    {
        Task<T> CreateAsync(T model);
        Task<T> GetByIdAsync(int id);
        T GetById(int? id);
        IQueryable<T> Get(Func<T, bool> predicate = null);
        T Delete(T model);
        T Edit(T model);
        Task SaveAsync();
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);
    }
}
