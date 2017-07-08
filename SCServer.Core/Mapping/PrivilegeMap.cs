using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class PrivilegeMap : BasicMap<Privilege>
    {
        public PrivilegeMap()
        {
            Table("Privilege");
            Map(x => x.FeatureId);
          
        }
    }
}
