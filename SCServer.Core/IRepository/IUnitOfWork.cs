using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Core.IRepository;
using NHibernate;

namespace SCServer.Core.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; set; }
        IEditionRepository EditionRepository { get; set; }
        IFeatureRepository FeatureRepository { get; set; }
        IModuleRepository  ModuleRepository { get; set; }
        IModulePrivilegeRepository ModulePrivilegeRepository { get; set; }
        IPrivilegeRepository PrivilegeRepository { get; set; }
        ISectionModulesRepository SectionModulesRepository { get; set; }
        ISectionRepository SectionRepository { get; set; }
       


        ISession Session { get; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }
}
