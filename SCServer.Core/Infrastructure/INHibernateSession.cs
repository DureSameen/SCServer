using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace SCServer.Core.Infrastructure
{
    public interface INHibernateSession
    {
        ISession OpenSession();
    }
}
