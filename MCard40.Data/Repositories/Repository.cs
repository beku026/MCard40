using MCard40.Data.Context;
using MCard40.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Data.Repositories
{
    /// <summary>
    /// Репозиторий
    /// </summary>
    public class Repository<T, TId> : IRepository<T, TId>
              where T : class,IEntity<TId>
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
        public async Task<T> Create(T model)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            var a = _context.Set<T>().Add(model);
            _context.SaveChanges();

            return a.Entity;
        }

        /// <summary>
        /// Читать все
        /// </summary>
        /// <returns></returns>
        public List<T> ReadAll()
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            var list = _context.Set<T>().ToList();

            return list;
        }

        /// <summary>
        /// удаление модельки из бд
        /// </summary>
        /// <param name="model"></param>
        public T Delete(T model)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            _context.Set<T>().Remove(model);

            _context.SaveChanges();

            return model;
        }

        /// <summary>
        /// удаление по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T DeleteById(TId id)
        {
            var entity = ReadById(id);
            _context.Set<T>().Remove(entity);

            _context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// изменение модельки
        /// </summary>
        public T Update(T entity)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }

            var a = _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return a.Entity;
        }

        /// <summary>
        /// Существует
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsExists(TId id)
        {
            return _context.Set<T>().Any(entity => entity.Id.Equals(id));
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
        public T ReadById(TId id)
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
