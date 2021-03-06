﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class ModulePrivilegeMap : AuditableMap<ModulePrivilege>
    {
        public ModulePrivilegeMap()
        {
            Table("ModulePrivileges");
                Map(e=>e.CustomerId);
                Map(e=>e.ModuleId);
                Map(e=>e.FeatureId);
                Map(e=>e.PrivilegeId);
                Map(e=>e.EditionId);
       
        
           
        }
    }
}
