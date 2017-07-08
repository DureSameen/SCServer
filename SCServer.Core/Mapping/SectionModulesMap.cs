using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class SectionModulesMap : BaseMap<SectionModules>
    {
        public SectionModulesMap()
        {
            Table("SectionModules");
                
                Map(e=>e.ModuleId);
               
                Map(e=>e.SectionId);

                Map(e => e.Enabled);

                Map(e => e.Sort_Key);
           
        }
    }
}
