using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.IRepository;
using SCServer.Core.Infrastructure;
using NHibernate;

namespace SCServer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession _session;
        private ITransaction _transaction;
        private ICustomerRepository _customerRepository;
        private ICustomerModuleRepository _customerModuleRepository;

        public ISession Session { get { return _session; } }

        public ICustomerRepository CustomerRepository { get { return _customerRepository; } set { _customerRepository = value; } }
        public ICustomerModuleRepository CustomerModuleRepository { get { return _customerModuleRepository; } set { _customerModuleRepository = value; } }


        public UnitOfWork(INHibernateContext context, ICustomerRepository customerRepository)
        {
            _session = context.NHibernateSession;
            _customerRepository = customerRepository;
            
             
        }
        public UnitOfWork(INHibernateContext context, ICustomerRepository customerRepository, ICustomerModuleRepository customerModuleRepository)
        {
            _session = context.NHibernateSession;
            _customerRepository = customerRepository;
            _customerModuleRepository = customerModuleRepository;

        }
        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transaction == null || !_transaction.IsActive)
            {
                if (_transaction != null)
                    _transaction.Dispose();

                _transaction = _session.BeginTransaction(isolationLevel);
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                _session.Dispose();
            }
        }

        void IDisposable.Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
        }
    }
}
