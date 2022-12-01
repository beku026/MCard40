using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCard40.Model.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>()
            where T : class, IEntity<int>;

        public IRepositoryUser<T> GetRepositoryUser<T>()
          where T : IdentityUser;
    }
}
