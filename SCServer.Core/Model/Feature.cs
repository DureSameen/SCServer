 using System;
 using System.Collections.Generic;
   
 namespace SCServer.Core.Model
{

     public partial class Feature : BasicEntity
    {
        public Feature()
        {
            CustomerModules = new List<CustomerModule>();
            Privileges = new List<Privilege>();
        }

        public virtual Guid? ModuleId { get; set; }

        public virtual IList<CustomerModule> CustomerModules { get; set; }

        public virtual Module Module { get; set; }

        public virtual IList<Privilege> Privileges { get; set; }
    }
}
