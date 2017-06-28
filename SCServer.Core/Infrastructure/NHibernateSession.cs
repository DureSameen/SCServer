using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.Model;
using SCServer.Core.Infrastructure;
using SCServer.Core.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace SCServer.Core.Infrastructure
{
    public class NHibernateSession : INHibernateSession
    {
        private ISessionFactory _sessionFactory;
        private string _connectionString;

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        public NHibernateSession(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(_connectionString)
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
