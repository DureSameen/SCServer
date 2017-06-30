using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Module : BasicEntity
    {
        public Module()
        {
            EditionModules = new List<EditionModule>();
            Features = new List<Feature>();
        }


      

        public virtual IList<EditionModule> EditionModules { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}
