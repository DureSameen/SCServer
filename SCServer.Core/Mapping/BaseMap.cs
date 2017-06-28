using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public abstract class BaseMap<T> : ClassMap<T> where T : Entity<Guid>
    {
        public BaseMap()
        {
            Id(x => x.Id);
          
        }
    }
}
