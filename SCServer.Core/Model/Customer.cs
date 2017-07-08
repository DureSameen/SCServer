 
    using System;
    using System.Collections.Generic;
 
namespace SCServer.Core.Model
{
    
    public class Customer:  BasicEntity
    {
        public Customer()
        {
            ModulePrivileges = new List<ModulePrivilege>();
        }

        public virtual Guid? EditionId { get; set; }
       
        public virtual Guid? SecurityKey { get; set; }
        public virtual Edition Edition { get; set; }
        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }
    }
}
