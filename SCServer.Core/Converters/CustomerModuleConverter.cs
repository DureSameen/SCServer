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
    public static class EditionModuleConverter
    {
        public static Dto.EditionModule ConvertToDto(this Model.EditionModule EditionModule)
        {
            Dto.EditionModule EditionModuleDto = new Dto.EditionModule
            {
                Id = EditionModule.Id,
                CustomerId= EditionModule.CustomerId,
                FeatureId = EditionModule.FeatureId,
                ModuleId= EditionModule.ModuleId,
                PrivilegeId= EditionModule.PrivilegeId
            }; 

            return EditionModuleDto;
        }

        public static Model.EditionModule ConvertToEntity(this Dto.EditionModule EditionModuleDto, Model.EditionModule EditionModule = null)
        {
            if (EditionModule == null)
                EditionModule = new Model.EditionModule();

                EditionModule.Id = EditionModuleDto.Id;
                EditionModule.CustomerId= EditionModuleDto.CustomerId;
                EditionModule.FeatureId = EditionModuleDto.FeatureId;
                EditionModule.ModuleId= EditionModuleDto.ModuleId;
                EditionModule.PrivilegeId = EditionModuleDto.PrivilegeId;
           

            return EditionModule;
        }
    }
}
