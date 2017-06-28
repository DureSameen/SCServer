using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.Dto
{
    public class AuditableDto: BaseDto 
    {

      public  DateTime CreatedOn { get; set; }
    }
}
