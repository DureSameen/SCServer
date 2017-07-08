using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/modulePrivilege")]
    public class ModulePrivilegeController : ApiController
    {  
        
        
        private readonly IModulePrivilegeService _modulePrivilegeService;

        public ModulePrivilegeController(IModulePrivilegeService modulePrivilegeService)
        {
            _modulePrivilegeService = modulePrivilegeService;
        }

        public IList<Core.Dto.ModulePrivilege> Get()
        {
            IList<Core.Dto.ModulePrivilege> modulePrivileges = _modulePrivilegeService.GetAll();

            return modulePrivileges;
        }

        public Core.Dto.ModulePrivilege Get(Guid id)
        {
            return _modulePrivilegeService.Get(id);
        }

        public Core.Dto.ModulePrivilege Post(Core.Dto.ModulePrivilege modulePrivilege)
        {
            return _modulePrivilegeService.Create(modulePrivilege);
        }

        public Core.Dto.ModulePrivilege Put(Core.Dto.ModulePrivilege modulePrivilege)
        {
            return _modulePrivilegeService.Update(modulePrivilege);
        }

        public void Delete(Guid id)
        {
            _modulePrivilegeService.Delete(id);
        }




    }
}
