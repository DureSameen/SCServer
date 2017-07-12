using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/module")]
    public class ModuleController : ApiController
    {  
        
        
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public IList<Core.Dto.Module> Get()
        {
            IList<Core.Dto.Module> modules = _moduleService.GetAll();

            return modules;
        }

        public Core.Dto.Module Get(Guid id)
        {
            return _moduleService.Get(id);
        }

        public Core.Dto.Module Post(Core.Dto.Module module)
        {
            return _moduleService.Create(module);
        }

        public Core.Dto.Module Put(Core.Dto.Module module)
        {
            return _moduleService.Update(module);
        }

        

        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            _moduleService.Delete(id);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
         

    }
}
