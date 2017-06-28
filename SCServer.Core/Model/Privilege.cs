using System;
using System.Collections.Generic;



namespace SCServer.Core.Model
{    
    public partial class Privilege: BasicEntity
    {
        public Privilege()
        {
            CustomerModules = new List<CustomerModule>();
        }
         

        public virtual Guid? FeatureId { get; set; }

        public virtual IList<CustomerModule> CustomerModules { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
