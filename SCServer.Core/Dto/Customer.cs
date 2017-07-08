 
    using System;
    using System.Collections.Generic;
 
namespace SCServer.Core.Dto
{

    public   class Customer : BasicDto
    {


        public Guid? EditionId { get; set; }
        public Guid? SecurityKey { get; set; }
        public virtual Edition Edition  { get; set; }
        public virtual IList<ModulePrivilege> ModulePrivileges { get; set; }
    }
}
