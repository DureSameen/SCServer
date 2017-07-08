using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCServer.Common.Helpers;
using SCServer.Core;
using SCServer.Core.Dto;
using SCServer.Core.Model;

namespace SCServer.Core.Converters
{
    public static class FeatureConverter
    {
        public static Dto.Feature ConvertToDto(this Model.Feature feature)
        {
            Dto.Feature featureDto = new Dto.Feature
            {
                Enabled = feature.Enabled,
                Id = feature.Id,
                Module = feature.Module.ConvertToDto(),
                ModuleId = feature.ModuleId,
                ModulePrivileges = feature.ModulePrivileges.ForeachToDto(),
                Name = feature.Name,
                Privileges = feature.Privileges.ForeachToDto()
            };

            return featureDto;
        }

        public static Model.Feature ConvertToEntity(this Dto.Feature featureDto, Model.Feature feature = null) {

            if (feature == null)
            {
                feature = new Model.Feature();
            }

            feature.Enabled = featureDto.Enabled;
            feature.Id = featureDto.Id;
            feature.Module = featureDto.Module.ConvertToEntity();
            feature.ModuleId = featureDto.ModuleId;
            feature.ModulePrivileges = featureDto.ModulePrivileges.ForeachToEntity();
            feature.Name = featureDto.Name;
            feature.Privileges = featureDto.Privileges.ForeachToEntity();

            return feature;
        }

        public static List<Dto.Feature> ForeachToDto(this IList<Model.Feature> features) {

            List<Dto.Feature> featuresDto = new List<Dto.Feature>();

            foreach (var feature in features)
            {
                featuresDto.Add(feature.ConvertToDto());
            }

            return featuresDto;
        }

        public static List<Model.Feature> ForeachToEntity(this IList<Dto.Feature> featuresDto)
        {

            List<Model.Feature> features = new List<Model.Feature>();

            foreach (var featureDto in featuresDto)
            {
                features.Add(featureDto.ConvertToEntity());
            }

            return features;
        }
    }
}
