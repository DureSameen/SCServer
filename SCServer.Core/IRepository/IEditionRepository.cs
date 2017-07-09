using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;

namespace SCServer.Core.IRepository
{
    public interface IEditionRepository : IBaseRepository<Edition, Guid>
    {
        Edition Get(Guid? id, bool include_children = false);
    }
}
