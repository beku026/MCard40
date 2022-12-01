using MCard40.Data.Context;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Data.Repositories
{
    public class Repository<T> : IRepository<T>
              where T : class, IEntity<int>
    {
        private readonly MCard40DbContext _context;
        private readonly DbSet<T> _set;
        public Repository(MCard40DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        /// <summary>
        /// Добавление модельки в бд
        /// </summary>
        /// <param name="model"></param>
        public async Task<T> CreateAsync(T model)
        {
            if (model == null)
            {
                return null;
            }


            await _set.AddAsync(model);
            return model;
        }

        /// <summary>
        /// удаление модельки из бд
        /// </summary>
        /// <param name="model"></param>
        public void Delete(T model)
        {
            if (_set.Any(x => x.Id == model.Id))
            {
                _set.Remove(model);
            }
        }

        /// <summary>
        /// изменение модельки
        /// </summary>
        /// <param name="model"></param>
        public void Edit(T model)
        {
            if (_set.Any(x => x.Id == model.Id))
            {
                _set.Update(model);
            }
        }

        /// <summary>
        /// Получение модельки по определенным условиям
        /// </summary>
        /// <param name="predicate"></param>
        public List<T> GetAsync(Func<T, bool> predicate = null)
        {
            var items = _set.AsQueryable();
            if (predicate != null)
            {
                items = items.Where(predicate).AsQueryable();
            }
            return items.ToList();
        }

        /// <summary>
        /// Взять модельку по Id
        /// </summary>
        /// <param name="id"></param>
        public T GetById(int id)
        {
            return _set.Find(id);
        }

        /// <summary>
        /// Взять модельку ассинхронным способом
        /// </summary>
        /// <param name="id"></param>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        /// <summary>
        /// сохранить все изменения в бд
        /// </summary>
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                return Include(includeProperties).Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _set.AsNoTracking();
            return includes
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void EditEntry(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }
    }
}
