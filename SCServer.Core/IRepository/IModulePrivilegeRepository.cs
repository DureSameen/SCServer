using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;

namespace SCServer.Core.IRepository
{
    public interface IModulePrivilegeRepository : IBaseRepository<ModulePrivilege, Guid>
    {
        IEnumerable<ModulePrivilege> GetByEditionId(Guid? EditionId);

    }
}
