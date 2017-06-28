using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.Model
{
    public abstract class AuditableEntity : Entity<Guid>, IAudit
    {
        public DateTime CreatedOn { get; set; }
    }
}
