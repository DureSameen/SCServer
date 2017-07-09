using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/section")]
    public class SectionController : ApiController
    {  
        
        
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
         [Route("by_editionid/{editionid}")]
        [HttpGet]
        public IList<Core.Dto.Section> By_editionid(Guid editionid)
        {
            IList<Core.Dto.Section> sections = _sectionService.GetAllbyEditionId(editionid);

            return sections;
        }

        public IList<Core.Dto.Section> Get()
        {
            IList<Core.Dto.Section> sections = _sectionService.GetAll();

            return sections;
        }

        public Core.Dto.Section Get(Guid id)
        {
            return _sectionService.Get(id);
        }

        public Core.Dto.Section Post(Core.Dto.Section section)
        {
            return _sectionService.Create(section);
        }

        public Core.Dto.Section Put(Core.Dto.Section section)
        {
            return _sectionService.Update(section);
        }

        public void Delete(Guid id)
        {
            _sectionService.Delete(id);
        }


         


    }
}
