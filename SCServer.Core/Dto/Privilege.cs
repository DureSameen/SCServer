using System;
using System.Collections.Generic;



namespace SCServer.Core.Dto
{    
    public   class Privilege: BasicDto
    { 
        public Guid? FeatureId { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
