using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SCServer.Common.Helpers;
using SCServer.Core.Converters;
using SCServer.Core.Dto;
using SCServer.Core.Infrastructure;
using SCServer.Core.IRepository;
using SCServer.Core.IService;
using SCServer.Core.Model;
using System.Web;
using System.IO.Compression;
using SC.ViewModel;

namespace SCServer.Service
{
    public class FeatureService : IFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeatureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Feature Get(Guid id)
        {
            var feature = _unitOfWork.FeatureRepository.Get(id);

            if (feature == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Feature not found!", "Please provide correct ID.");

                return null;
            }

            return feature.ConvertToDto();
        }

        public IList<Core.Dto.Feature> GetAll()
        {
            var features = _unitOfWork.FeatureRepository.GetAll();
            IList<Core.Dto.Feature> featuresDto = new List<Core.Dto.Feature>();

            foreach (var feature in features)
            {
                featuresDto.Add(feature.ConvertToDto());
            }

            return featuresDto;
        }

        public Core.Dto.Feature Create(Core.Dto.Feature featureDto)
        {
            var feature = featureDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.FeatureRepository.Create(feature);

            featureDto = feature.ConvertToDto();

            _unitOfWork.Commit();

            return featureDto;
        }

        public Core.Dto.Feature Update(Core.Dto.Feature featureDto)
        {
             

            var existingFeatureDto = _unitOfWork.FeatureRepository.Get(featureDto.Id).ConvertToDto();

            existingFeatureDto.Name = featureDto.Name;
            existingFeatureDto.ModuleId = featureDto.ModuleId;  
            existingFeatureDto.Enabled = featureDto.Enabled;
            _unitOfWork.BeginTransaction();

            var feature = _unitOfWork.FeatureRepository.Update(existingFeatureDto.ConvertToEntity());

            _unitOfWork.Commit();

            featureDto = feature.ConvertToDto();

            return featureDto;
        }

        public void Delete(Guid id)
        {
            var feature = _unitOfWork.FeatureRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.FeatureRepository.Delete(feature);
            _unitOfWork.Commit();
        }

        



    }
}
