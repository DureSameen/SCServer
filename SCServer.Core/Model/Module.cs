using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Module : BasicEntity
    {
        public Module()
        {
            CustomerModules = new List<CustomerModule>();
            Features = new List<Feature>();
        }


      

        public virtual IList<CustomerModule> CustomerModules { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}
