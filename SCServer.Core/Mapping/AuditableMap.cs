using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public abstract class AuditableMap<T> : BaseMap<T> where T : AuditableEntity
    {
        public AuditableMap()
        {
            Map(x => x.CreatedOn);
        }
    }
}
