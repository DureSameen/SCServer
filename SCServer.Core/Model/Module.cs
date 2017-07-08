using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Module : BasicEntity
    {
        public Module()
        {
            ModulePrivileges = new List<ModulePrivilege>();
            Features = new List<Feature>();
        }



        public virtual string TypeName { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}
