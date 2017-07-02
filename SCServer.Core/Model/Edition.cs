using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Edition : BasicEntity
    {
        public Edition()
        {
            EditionModules = new List<EditionModule>();
           
        }

         
        public virtual IList<EditionModule> EditionModules { get; set; }

        
    }
}
