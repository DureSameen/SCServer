using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using SCServer.Core.IRepository;
using SCServer.Core.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace SCServer.Repository
{
    public class EditionModuleRepository : BaseRepository<EditionModule, Guid>, IEditionModuleRepository
    {
        private ISession _session;

        public EditionModuleRepository(INHibernateContext context)
            : base(context)
        {
            _session = context.NHibernateSession;
        }
    }
}
