using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.IRepository
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        IQueryable<TEntity> GetAll();
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
