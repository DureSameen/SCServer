using System;
using System.Collections.Generic;



namespace SCServer.Core.Dto
{    
    public   class Privilege: BasicDto
    { 
        public Guid? FeatureId { get; set; }

        public virtual IList<EditionModule> EditionModules { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
