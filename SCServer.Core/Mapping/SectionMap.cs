using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class SectionMap : BasicMap<Section>
    {
        public SectionMap()
        {
            Table("Section");
            Map(x => x.EditionId);
            Map(x => x.Sort_Key);
        }
    }
}
