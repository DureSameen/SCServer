using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Attributes;
using SCServer.Core.Enums;
using SCServer.Core.IRepository;
using SCServer.Core.Infrastructure;
using SCServer.Core.Model;
using NHibernate;
using NHibernate.Linq;

namespace SCServer.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private ISession _session;

        public BaseRepository(INHibernateContext context)
        {
            _session = context.NHibernateSession;
        }

        [AuditOperation(OperationType.Read)]
        public virtual TEntity Get(TKey id)
        {
            return _session.Get<TEntity>(id);
        }

        [AuditOperation(OperationType.Read)]
        public virtual IQueryable<TEntity> GetAll()
        {
            return _session.Query<TEntity>();
        }

        [AuditOperation(OperationType.Create)]
        public virtual TEntity Create(TEntity entity)
        {
            _session.Clear();
            _session.Flush();
            _session.Save(entity);
            return entity;
        }

        [AuditOperation(OperationType.Update)]
        public virtual TEntity Update(TEntity entity)
        {
            _session.Clear();
            _session.Flush();
            _session.Update(entity);
            return entity;
        }

        [AuditOperation(OperationType.Delete)]
        public virtual void Delete(TEntity entity)
        {
            _session.Clear();
            _session.Flush();
            _session.Delete(entity);
        }
    }
}
//edit 