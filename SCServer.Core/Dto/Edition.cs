using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public class Edition : BasicDto
    {


        public virtual int Sort_Key { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual IList<Section> Sections { get; set; }
         
    }
}
