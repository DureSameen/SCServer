using System;
using System.Collections.Generic;

namespace SCServer.Core.Model
{


    public partial class Section : BasicEntity
    {
        public Section()
        {
            Edition = new Edition();
             Modules =new List<Module>();
        }
        public virtual int Sort_Key { get; set; }

        public virtual Guid? EditionId { get; set; }

        public virtual Edition Edition { get; set; }

        public virtual IList<Module> Modules { get; set; }
      
    }
}
