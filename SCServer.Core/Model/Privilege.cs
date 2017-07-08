using System;
using System.Collections.Generic;



namespace SCServer.Core.Model
{    
    public partial class Privilege: BasicEntity
    {
        public Privilege()
        {
            ModulePrivileges = new List<ModulePrivilege>();
        }
         

        public virtual Guid? FeatureId { get; set; }

        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
