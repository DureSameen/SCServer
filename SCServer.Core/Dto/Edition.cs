using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public class Edition : BasicDto
    {

        

        public virtual IList<EditionModule> EditionModules { get; set; }

         
    }
}
