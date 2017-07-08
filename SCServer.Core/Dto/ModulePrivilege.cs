using System;
using System.Collections.Generic;

 namespace  SCServer.Core.Dto
{

     public   class ModulePrivilege :AuditableDto
    {
         

        public Guid? CustomerId { get; set; }

        public Guid? ModuleId { get; set; }

        public Guid? FeatureId { get; set; }

        public Guid? PrivilegeId { get; set; }

        public Guid? EditionId { get; set; }

        public virtual Edition Edition { get; set; }


        public virtual Customer Customer { get; set; }

        public virtual Feature Feature { get; set; }

        public virtual Module Module { get; set; }

        public virtual Privilege Privilege { get; set; }
    }
}
