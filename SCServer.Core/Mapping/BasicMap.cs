using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public abstract class BasicMap<T> : BaseMap<T> where T : BasicEntity 
    {
        public BasicMap()
        {
            Map(x => x.Name);
            Map(x => x.Enabled);
        }
    }
}
