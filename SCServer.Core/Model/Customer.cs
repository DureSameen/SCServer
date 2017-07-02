 
    using System;
    using System.Collections.Generic;
 
namespace SCServer.Core.Model
{
    
    public class Customer:  BasicEntity
    {
        public Customer()
        {
            EditionModules = new List<EditionModule>();
        }

        public virtual Guid? EditionId { get; set; }
       
        public virtual Guid? SecurityKey { get; set; }
        public virtual Edition Edition { get; set; }
        public virtual IList<EditionModule> EditionModules { get; set; }
    }
}
