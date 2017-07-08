using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/edition")]
    public class EditionController : ApiController
    {  
        
        
        private readonly IEditionService _editionService;

        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        public IList<Core.Dto.Edition> Get()
        {
            IList<Core.Dto.Edition> editions = _editionService.GetAll();

            return editions;
        }

        public Core.Dto.Edition Get(Guid id)
        {
            return _editionService.Get(id);
        }

        public Core.Dto.Edition Post(Core.Dto.Edition edition)
        {
            return _editionService.Create(edition);
        }

        public Core.Dto.Edition Put(Core.Dto.Edition edition)
        {
            return _editionService.Update(edition);
        }

        public void Delete(Guid id)
        {
            _editionService.Delete(id);
        }


        

    }
}
