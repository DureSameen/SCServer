using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    [RoutePrefix("api/feature")]
    public class FeatureController : ApiController
    {  
        
        
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IList<Core.Dto.Feature> Get()
        {
            IList<Core.Dto.Feature> features = _featureService.GetAll();

            return features;
        }

        public Core.Dto.Feature Get(Guid id)
        {
            return _featureService.Get(id);
        }

        public Core.Dto.Feature Post(Core.Dto.Feature feature)
        {
            return _featureService.Create(feature);
        }

        public Core.Dto.Feature Put(Core.Dto.Feature feature)
        {
            return _featureService.Update(feature);
        }

        public void Delete(Guid id)
        {
            _featureService.Delete(id);
        }


        

    }
}
