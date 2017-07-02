using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class ModuleMap : BasicMap<Module>
    {
        public ModuleMap()
        {
            Table("Module");
            Map(m => m.TypeName);
           
        }
    }
}
