using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using SCServer.Core.IRepository;
using SCServer.Core.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace SCServer.Repository
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        private ISession _session;

        public CustomerRepository(INHibernateContext context)
            : base(context)
        {
            _session = context.NHibernateSession;
        }

        public Customer GetBySecretKey(Guid key)
        {

            return _session.Query<Customer>().Where(c => c.SecurityKey == key).FirstOrDefault(); 
        
        }
    }
}
