using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Model.Interfaces
{
    public interface IRepositoryUser<T> where T : IdentityUser
    {
        Task<T> CreateAsync(T model);
        Task<T> GetByIdAsync(string id);
        T GetById(string id);
        //Task<List<T>> GetAsync(Func<T, bool> predicate = null);
        List<T> Get(Func<T, bool> predicate = null);
        void Delete(T model);
        void Edit(T model);
        Task SaveAsync();
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties);
    }
}
