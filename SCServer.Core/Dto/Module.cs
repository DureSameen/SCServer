using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public class Module : BaseDto
    {
         

        public virtual IList<EditionModule> EditionModules { get; set; }

        public virtual IList<Feature> Features { get; set; }
    }
}
