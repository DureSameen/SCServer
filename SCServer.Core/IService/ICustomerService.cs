﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Dto;

namespace SCServer.Core.IService
{
    public interface ICustomerService : IBaseService<Customer, Guid>
    {
        string GetEditionUrl(Guid secretkey);
    }
}
