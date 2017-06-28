using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Mapping;
using NHibernate.Tool.hbm2ddl;
using SCServer.Core.Mapping;
using SCServer.Core.Infrastructure;

namespace SCServer.Service.Test.TestHelper
{
    public class InMemoryDatabaseTest : IDisposable, INHibernateContext
    {
        
        private const string PrototypeConnectionString = "FullUri=file:prototype.db?mode=memory&cache=shared";
        private static ISessionFactory _prototypeSessionFactory;
        private static SQLiteConnection _prototypeConnection;

        private const string InstanceConnectionString = "FullUri=file:instance.db?mode=memory&cache=shared";
        private ISessionFactory _instanceSessionFactory;
        private SQLiteConnection _instanceConnection;

        public InMemoryDatabaseTest()
        {
            InitDatabasePrototype();
            InitDatabaseInstance();
        }

        private void InitDatabasePrototype()
        {
           

            if (_prototypeConnection != null)
            {
                _prototypeConnection.Close();
                _prototypeConnection.Dispose();
                _prototypeSessionFactory.Dispose();
            }

           

            _prototypeConnection = new SQLiteConnection(PrototypeConnectionString);
            _prototypeConnection.Open();

            _prototypeSessionFactory = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(PrototypeConnectionString))
                .Mappings(m => m.FluentMappings
                            .Add(typeof(CustomerMap))
                      )
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false, true, false, _prototypeConnection, null))
                .BuildSessionFactory();
        }

        private void InitDatabaseInstance()
        {
            _instanceSessionFactory = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(InstanceConnectionString))
                .Mappings(m => m.FluentMappings
                            .Add(typeof(CustomerMap))
                      )
                .BuildSessionFactory();

            _instanceConnection = new SQLiteConnection(InstanceConnectionString);
            _instanceConnection.Open();

            _prototypeConnection.BackupDatabase(_instanceConnection, "main", "main", -1, null, -1);
        }

        public ISession OpenSession()
        {
            return _instanceSessionFactory.OpenSession(_instanceConnection);
        }
           public ISession NHibernateSession
        {
            get
            {
               return _instanceSessionFactory.OpenSession(_instanceConnection);
        }
            }
        
        public void Dispose()
        {
            _instanceConnection.Close();
            _instanceConnection.Dispose();
            _instanceSessionFactory.Dispose();
        }
    }
}