using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public class Module : BasicDto
    {

        public virtual string TypeName { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}
