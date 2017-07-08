using System;
using System.Collections.Generic;

namespace SCServer.Core.Dto
{


    public partial class SectionModules : BaseDto
    {
        
        public virtual Guid? ModuleId { get; set; }
        public virtual Guid? SectionId { get; set; }
        public virtual bool  Enabled { get; set; }
        public virtual int   Sort_Key { get; set; }


        public virtual Section Section { get; set; }

        public virtual Module Module { get; set; }
      
    }
}
