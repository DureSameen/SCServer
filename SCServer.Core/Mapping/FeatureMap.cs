using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using FluentNHibernate.Mapping;

namespace SCServer.Core.Mapping
{
    public class FeatureMap : BasicMap<Feature>
    {
        public FeatureMap()
        {
            Table("Feature");
            Map(x => x.ModuleId);
          
        }
    }
}
