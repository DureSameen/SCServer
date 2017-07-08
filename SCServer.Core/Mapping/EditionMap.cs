using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class EditionMap : BasicMap<Edition>
    {
        public EditionMap()
        {
            Table("Edition");

            Map(e => e.Sort_Key);
        }
    }
}
