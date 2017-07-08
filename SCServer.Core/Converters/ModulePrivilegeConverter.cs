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
    public static class ModulePrivilegeConverter
    {
        public static Dto.ModulePrivilege ConvertToDto(this Model.ModulePrivilege modulePrivilege)
        {
            Dto.ModulePrivilege modulePrivilegeDto = new Dto.ModulePrivilege
            {
                CreatedOn = modulePrivilege.CreatedOn,
                Customer = modulePrivilege.Customer.ConvertToDto(),
                CustomerId = modulePrivilege.CustomerId,
                Edition = modulePrivilege.Edition.ConvertToDto(),
                EditionId = modulePrivilege.EditionId,
                Feature = modulePrivilege.Feature.ConvertToDto(),
                FeatureId = modulePrivilege.FeatureId,
                Id = modulePrivilege.Id,
                Module = modulePrivilege.Module.ConvertToDto(),
                ModuleId = modulePrivilege.ModuleId,
                Privilege = modulePrivilege.Privilege.ConvertToDto(),
                PrivilegeId = modulePrivilege.PrivilegeId
            };

            return modulePrivilegeDto;
        }

        public static Model.ModulePrivilege ConvertToEntity(this Dto.ModulePrivilege modulePrivilegeDto, Model.ModulePrivilege modulePrivilege = null) {

            if (modulePrivilege == null)
            {
                modulePrivilege = new Model.ModulePrivilege();
            }

            modulePrivilege.CreatedOn = modulePrivilegeDto.CreatedOn;
            modulePrivilege.Customer = modulePrivilegeDto.Customer.ConvertToEntity();
            modulePrivilege.CustomerId = modulePrivilegeDto.CustomerId;
            modulePrivilege.Edition = modulePrivilegeDto.Edition.ConvertToEntity();
            modulePrivilege.EditionId = modulePrivilegeDto.EditionId;
            modulePrivilege.Feature = modulePrivilegeDto.Feature.ConvertToEntity();
            modulePrivilege.FeatureId = modulePrivilegeDto.FeatureId;
            modulePrivilege.Id = modulePrivilegeDto.Id;
            modulePrivilege.Module = modulePrivilegeDto.Module.ConvertToEntity();
            modulePrivilege.ModuleId = modulePrivilegeDto.ModuleId;
            modulePrivilege.Privilege = modulePrivilegeDto.Privilege.ConvertToEntity();
            modulePrivilege.PrivilegeId = modulePrivilegeDto.PrivilegeId;

            return modulePrivilege;
        }

        public static List<Dto.ModulePrivilege> ForeachToDto(this IList<Model.ModulePrivilege> modulePrivileges) {

            List<Dto.ModulePrivilege> modulePrivilegesDto = new List<Dto.ModulePrivilege>();

            foreach (var modulePrivilege in modulePrivileges)
            {
                modulePrivilegesDto.Add(modulePrivilege.ConvertToDto());
            }

            return modulePrivilegesDto;
        }

        public static List<Model.ModulePrivilege> ForeachToEntity(this IList<Dto.ModulePrivilege> modulePrivilegesDto)
        {

            List<Model.ModulePrivilege> modulePrivileges = new List<Model.ModulePrivilege>();

            foreach (var modulePrivilegeDto in modulePrivilegesDto)
            {
                modulePrivileges.Add(modulePrivilegeDto.ConvertToEntity());
            }

            return modulePrivileges;
        }
    }
}
