using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Edition : BasicEntity
    {
        public Edition()
        {
            ModulePrivileges = new List<ModulePrivilege>();
            Sections = new List<Section>();
        }

        public virtual int Sort_Key { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual IList<Section> Sections { get; set; }
    }
}
