using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Model.Interfaces
{
    public interface IRepository<T> where T : class, IEntity<int>
    {
        public T Create(T entity);
        public List<T> ReadAll();
        public T ReadById(int id);
        public T Update(T entity);
        public void Delete(T entity);
        public void DeleteById(int id);
    }
}
