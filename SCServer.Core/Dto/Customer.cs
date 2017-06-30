 
    using System;
    using System.Collections.Generic;
 
namespace SCServer.Core.Dto
{

    public   class Customer : BasicDto
    {
        

       
        public Guid? SecurityKey { get; set; }

        public virtual IList<EditionModule> EditionModules { get; set; }
    }
}
