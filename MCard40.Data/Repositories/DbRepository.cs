using MCard40.Data.Context;
using MCard40.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Data.Repositories
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity<int>
    {
        protected readonly MCard40DbContext Ctx;

        public DbRepository(MCard40DbContext ctx)
        {
            Ctx = ctx;
        }
        public T Create(T entity)
        {
            var a = Ctx.Set<T>().Add(entity);
            Ctx.SaveChanges();

            return a.Entity;
        }
        public List<T> ReadAll()
        {
            var list = Ctx.Set<T>().ToList();

            return list;
        }
        public T ReadById(int id)
        {
            var entity = Ctx.Set<T>().FirstOrDefault(en => en.Id == id);
            return entity;
        }
        public T Update(T entity)
        {
            var a = Ctx.Set<T>().Update(entity);
            Ctx.SaveChanges();

            return a.Entity;
        }
        public void Delete(T entity)
        {
            Ctx.Set<T>().Remove(entity);

            Ctx.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var entity = ReadById(id);
            Ctx.Set<T>().Remove(entity);

            Ctx.SaveChanges();
        }
    }
}
