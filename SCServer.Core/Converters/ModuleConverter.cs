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
    public static class ModuleConverter
    {
        public static Dto.Module ConvertToDto(this Model.Module module)
        {
            Dto.Module moduleDto = new Dto.Module
            {
                Enabled = module.Enabled,
                Features = module.Features.ForeachToDto(),
                Id = module.Id,
                ModulePrivileges = module.ModulePrivileges.ForeachToDto(),
                Name = module.Name,
                TypeName = module.TypeName
            };

            return moduleDto;
        }

        public static Model.Module ConvertToEntity(this Dto.Module moduleDto, Model.Module module = null) {

            if (module == null)
            {
                module = new Model.Module();
            }

            module.Enabled = moduleDto.Enabled;
            module.Features = moduleDto.Features.ForeachToEntity();
            module.Id = moduleDto.Id;
            module.ModulePrivileges = moduleDto.ModulePrivileges.ForeachToEntity();
            module.Name = moduleDto.Name;
            module.TypeName = moduleDto.TypeName;

            return module;
        }
    }
}
