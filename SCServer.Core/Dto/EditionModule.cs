using System;
using System.Collections.Generic;

 namespace  SCServer.Core.Dto
{

     public   class EditionModule :AuditableDto
    {
         

        public Guid? CustomerId { get; set; }

        public Guid? ModuleId { get; set; }

        public Guid? FeatureId { get; set; }

        public Guid? PrivilegeId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual Module Module { get; set; }

        public virtual Privilege Privilege { get; set; }
    }
}
