using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCServer.Common.Helpers;
using SCServer.Core.Infrastructure;
using NHibernate;

namespace SCServer.Api.Infrastructure
{
    public class NHibernateContext : INHibernateContext
    {
        private readonly string _connectionString = ConfigurationHelper.GetConnectionString("SocomServer_Conn");
        private const string _nHibernateContext = "NHibernateContext";

        public ISession NHibernateSession
        {
            get
            {
                ISession nHibernateSession;

                if (HttpContext.Current.Items.Contains(_nHibernateContext))
                    nHibernateSession = (ISession)HttpContext.Current.Items[_nHibernateContext];
                else
                {
                    nHibernateSession = new NHibernateSession(_connectionString).OpenSession();
                    HttpContext.Current.Items[_nHibernateContext] = nHibernateSession;
                }

                return nHibernateSession;
            }
        }
    }
}
