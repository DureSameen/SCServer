using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.IService
{
    public interface IBaseService<TEntity, TKey>
    {
        TEntity Get(TKey id);
        IList<TEntity> GetAll();
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TKey id);
    }
}
