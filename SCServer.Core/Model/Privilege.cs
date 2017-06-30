using System;
using System.Collections.Generic;



namespace SCServer.Core.Model
{    
    public partial class Privilege: BasicEntity
    {
        public Privilege()
        {
            EditionModules = new List<EditionModule>();
        }
         

        public virtual Guid? FeatureId { get; set; }

        public virtual IList<EditionModule> EditionModules { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
