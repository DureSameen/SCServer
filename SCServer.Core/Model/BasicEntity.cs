using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCServer.Core.Model
{
    public abstract class BasicEntity : Entity<Guid>, IBasicEntity
    {
        public virtual string Name { get; set; }
        public virtual bool Enabled { get; set; }
        
    }
}
