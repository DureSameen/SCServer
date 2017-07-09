using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Dto;

namespace SCServer.Core.IService
{
    public interface ISectionService : IBaseService<Section, Guid>
    {
        IList<Core.Dto.Section> GetAllbyEditionId(Guid EditionId);
    }
}
