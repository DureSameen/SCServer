using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/sectionModules")]
    public class SectionModulesController : ApiController
    {  
        
        
        private readonly ISectionModulesService _sectionModulesService;

        public SectionModulesController(ISectionModulesService sectionModulesService)
        {
            _sectionModulesService = sectionModulesService;
        }

        public IList<Core.Dto.SectionModules> Get()
        {
            IList<Core.Dto.SectionModules> sectionModuless = _sectionModulesService.GetAll();

            return sectionModuless;
        }

        public Core.Dto.SectionModules Get(Guid id)
        {
            return _sectionModulesService.Get(id);
        }

        public Core.Dto.SectionModules Post(Core.Dto.SectionModules sectionModules)
        {
            return _sectionModulesService.Create(sectionModules);
        }

        public Core.Dto.SectionModules Put(Core.Dto.SectionModules sectionModules)
        {
            return _sectionModulesService.Update(sectionModules);
        }

        public void Delete(Guid id)
        {
            _sectionModulesService.Delete(id);
        }


       


    }
}
