using System;
using System.Collections.Generic;

 namespace SCServer.Core.Model
{

     public partial class ModulePrivilege : AuditableEntity
    {
         

        public virtual Guid? CustomerId { get; set; }

        public virtual Guid? ModuleId { get; set; }

        public virtual Guid? FeatureId { get; set; }

        public virtual Guid? PrivilegeId { get; set; }

        public virtual Guid? EditionId { get; set; }

        public virtual Edition Edition { get; set; }


        public virtual Customer Customer { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual Module Module { get; set; }

        public virtual Privilege Privilege { get; set; }
    }
}
