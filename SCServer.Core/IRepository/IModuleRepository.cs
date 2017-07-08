using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;

namespace SCServer.Core.IRepository
{
    public interface IModuleRepository : IBaseRepository<Module, Guid>
    {
    }
}
