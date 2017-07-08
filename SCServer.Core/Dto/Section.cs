using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public partial class Section : BasicDto
    {
        public Section()
        {
            Edition = new Edition();
        }
        public virtual int Sort_Key { get; set; }

        public virtual Guid? EditionId { get; set; }

        public virtual Edition Edition { get; set; }


      
    }
}
