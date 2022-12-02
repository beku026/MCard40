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
        public Repository(MCard40DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление модельки в бд
        /// </summary>
        /// <param name="model"></param>
        public async Task<T> CreateAsync(T model)
        {
            if (model == null || _context.Set<T>() == null)
            {
                return null;
            }


            await _context.AddAsync(model);
            return model;
        }

        /// <summary>
        /// удаление модельки из бд
        /// </summary>
        /// <param name="model"></param>
        public T Delete(T model)
        {
            if (model == null || _context.Set<T>() == null)
            {
                return null;
            }

            if (_context.Set<T>().Any(x => x.Id == model.Id))
            {
                _context.Remove(model);
            }

            return model;
        }

        /// <summary>
        /// изменение модельки
        /// </summary>
        /// <param name="model"></param>
        public T Edit(T model)
        {
            if (model == null || _context.Set<T>() == null)
            {
                return null;
            }

            if (_context.Set<T>().Any(x => x.Id == model.Id))
            {
                _context.Update(model);
            }

            return model;
        }

        /// <summary>
        /// Получение модельки по определенным условиям
        /// </summary>
        /// <param name="predicate"></param>
        public IQueryable<T> Get(Func<T, bool> predicate = null)
        {
            var items = _context.Set<T>().AsQueryable();
            if (predicate != null)
            {
                items = items.Where(predicate).AsQueryable();
            }
            return items;
        }

        /// <summary>
        /// Взять модельку по Id
        /// </summary>
        /// <param name="id"></param>
        public T GetById(int? id)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Взять модельку ассинхронным способом
        /// </summary>
        /// <param name="id"></param>
        public async Task<T> GetByIdAsync(int id)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
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
            var doctors = Include(includeProperties);

            if(doctors == null)
            {
                return null;
            }

            return doctors.ToList();
        }

        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                var doctors = Include(includeProperties);

                if (doctors == null)
                {
                    return null;
                }

                return doctors.Where(predicate).ToList();
            }
            catch
            {
                return null;
            }
        }

        private IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            return includes
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
