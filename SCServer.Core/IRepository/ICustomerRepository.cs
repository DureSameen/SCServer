using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;

namespace SCServer.Core.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer, Guid>
    {

          Customer GetBySecretKey(Guid key);
    }
}
