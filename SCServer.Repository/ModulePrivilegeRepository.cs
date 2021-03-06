﻿using System;
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
    public class ModulePrivilegeRepository : BaseRepository<ModulePrivilege, Guid>, IModulePrivilegeRepository
    {
        private ISession _session;

        public ModulePrivilegeRepository(INHibernateContext context)
            : base(context)
        {
            _session = context.NHibernateSession;
        }


        public IEnumerable<ModulePrivilege> GetByEditionId(Guid? EditionId) 
      {

          var edition_modules= _session.Query<ModulePrivilege>().Where(em => em.EditionId == EditionId).ToList();
          for (int i = 0; i < edition_modules.Count;i++ )

          { edition_modules[i].Module = _session.Query<Module>().Where(m => m.Id == edition_modules[i].ModuleId).FirstOrDefault(); }


            return edition_modules;
      }
    }
}
