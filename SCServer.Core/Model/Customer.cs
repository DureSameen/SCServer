 
    using System;
    using System.Collections.Generic;
 
namespace SCServer.Core.Model
{
    
    public class Customer:  BasicEntity
    {
        public Customer()
        {
            CustomerModules = new List<CustomerModule>();
        }

        
        public virtual Guid? SecurityKey { get; set; }

        public virtual IList<CustomerModule> CustomerModules { get; set; }
    }
}
