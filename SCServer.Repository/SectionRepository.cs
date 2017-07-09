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
    public class SectionRepository : BaseRepository<Section, Guid>, ISectionRepository
    {
        private ISession _session;

        public SectionRepository(INHibernateContext context)
            : base(context)
        {
            _session = context.NHibernateSession;
        }

       public IList<Core.Model.Section> GetAllbyEditionId(Guid EditionId)
        {
            var sections=_session.Query<Section>().Where(s => EditionId == s.EditionId).ToList();


            return sections;
        }
    }
}
