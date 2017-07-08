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
        private IModulePrivilegeRepository _ModulePrivilegeRepository;
        private IEditionRepository _EditionRepository;
        private IFeatureRepository _FeatureRepository;
        private IModuleRepository _ModuleRepository;
        private IPrivilegeRepository _PrivilegeRepository;
        private ISectionRepository _SectionRepository;
        private ISectionModulesRepository _SectionModulesRepository;


        public ISession Session { get { return _session; } }

        public ICustomerRepository CustomerRepository { get { return _customerRepository; } set { _customerRepository = value; } }
        public IModulePrivilegeRepository ModulePrivilegeRepository { get { return _ModulePrivilegeRepository; } set { _ModulePrivilegeRepository = value; } }
        public IEditionRepository EditionRepository { get { return _EditionRepository; } set { _EditionRepository = value; } }
        public IFeatureRepository FeatureRepository { get { return _FeatureRepository; } set { _FeatureRepository = value; } }
        public IModuleRepository ModuleRepository { get { return _ModuleRepository; } set { _ModuleRepository = value; } }
        public IPrivilegeRepository PrivilegeRepository { get { return _PrivilegeRepository; } set { _PrivilegeRepository = value; } }
        public ISectionRepository SectionRepository { get { return _SectionRepository; } set { _SectionRepository = value; } }
        public ISectionModulesRepository SectionModulesRepository { get { return _SectionModulesRepository; } set { _SectionModulesRepository = value; } }
      

        public UnitOfWork(INHibernateContext context, 
            ICustomerRepository customerRepository)
        {

            _session = context.NHibernateSession;
            _customerRepository = customerRepository;

        }


        public UnitOfWork(INHibernateContext context, 
            ICustomerRepository customerRepository, 
            IModulePrivilegeRepository ModulePrivilegeRepository 
             )
        {
            _session = context.NHibernateSession;
            _customerRepository = customerRepository;
            _ModulePrivilegeRepository = ModulePrivilegeRepository;
          

        }

        public UnitOfWork(INHibernateContext context,
           ICustomerRepository customerRepository,
           IModulePrivilegeRepository ModulePrivilegeRepository,
           IEditionRepository editionRepository,
           IFeatureRepository featureRepository,
           IModuleRepository moduleRepository,
           IPrivilegeRepository privilegeRepository,
            ISectionRepository sectionRepository,
            ISectionModulesRepository sectionModulesRepository
            )
        {
            _session = context.NHibernateSession;
            _customerRepository = customerRepository;
            _ModulePrivilegeRepository = ModulePrivilegeRepository;
            _EditionRepository = editionRepository;
            _FeatureRepository = featureRepository;
            _ModuleRepository = moduleRepository;
            _PrivilegeRepository = privilegeRepository;
            _SectionRepository = sectionRepository;
            _SectionModulesRepository = sectionModulesRepository;

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
