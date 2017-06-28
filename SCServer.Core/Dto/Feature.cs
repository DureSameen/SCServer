 using System;
 using System.Collections.Generic;

namespace SCServer.Core.Dto
{

     public class Feature : BasicDto 
    { 

        public Guid? ModuleId { get; set; }

        public virtual IList<CustomerModule> CustomerModules { get; set; }

        public virtual Module Module { get; set; }

        public virtual IList<Privilege> Privileges { get; set; }
    }
}
