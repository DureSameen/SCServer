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
    public class EditionRepository : BaseRepository<Edition, Guid>, IEditionRepository
    {
        private ISession _session;

        public EditionRepository(INHibernateContext context)
            : base(context)
        {
            _session = context.NHibernateSession;
        }

        public Edition Get(Guid? id,  bool include_children=false)
        {
            var edition = base.Get(id.Value);
            try
            {
                var sections = _session.Query<Section>().Where(s => edition.Id == s.EditionId).ToList();
                if (sections.Count > 0 && include_children)
                {
                    edition.Sections = sections;

                    for (int i = 0; i < edition.Sections.Count; i++)
                    {
                        var sectionmodules = _session.Query<SectionModules>().Where(sm => edition.Sections[i].Id == sm.SectionId).OrderBy(sm => sm.Sort_Key).ToList();

                        for (int j = 0; j < sectionmodules.Count; j++)
                        {
                            var module = _session.Query<Module>().Where(m => sectionmodules[j].ModuleId == m.Id).FirstOrDefault();
                            if (module != null)
                                edition.Sections[i].Modules.Add(module);
                        }
                    }

                }
            }
            catch 
            {}
            return edition;
        }
    }
}
