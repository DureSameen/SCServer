﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;

namespace SCServer.Core.IRepository
{
    public interface ISectionRepository : IBaseRepository<Section, Guid>
    {
        IList<Core.Model.Section> GetAllbyEditionId(Guid EditionId);
    }
}
