using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/privilege")]
    public class PrivilegeController : ApiController
    {  
        
        
        private readonly IPrivilegeService _privilegeService;

        public PrivilegeController(IPrivilegeService privilegeService)
        {
            _privilegeService = privilegeService;
        }

        public IList<Core.Dto.Privilege> Get()
        {
            IList<Core.Dto.Privilege> privileges = _privilegeService.GetAll();

            return privileges;
        }

        public Core.Dto.Privilege Get(Guid id)
        {
            return _privilegeService.Get(id);
        }

        public Core.Dto.Privilege Post(Core.Dto.Privilege privilege)
        {
            return _privilegeService.Create(privilege);
        }

        public Core.Dto.Privilege Put(Core.Dto.Privilege privilege)
        {
            return _privilegeService.Update(privilege);
        }

        public void Delete(Guid id)
        {
            _privilegeService.Delete(id);
        }


       


    }
}
