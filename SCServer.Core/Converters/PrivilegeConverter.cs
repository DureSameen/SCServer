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
    public static class PrivilegeConverter
    {
        public static Dto.Privilege ConvertToDto(this Model.Privilege privilege) {

            Dto.Privilege privilegeDto = new Dto.Privilege {
				Enabled = privilege.Enabled,
				Feature = privilege.Feature.ConvertToDto(),
				FeatureId = privilege.FeatureId,
				Id = privilege.Id,
				ModulePrivileges = privilege.ModulePrivileges.ForeachToDto(),
				Name = privilege.Name
            };

            return privilegeDto;
        }

        public static Model.Privilege ConvertToEntity(this Dto.Privilege privilegeDto, Model.Privilege privilege = null) {

            if (privilege == null)
            {
                privilege = new Model.Privilege();
            }

            privilege.Enabled = privilegeDto.Enabled;
            privilege.Feature = privilegeDto.Feature.ConvertToEntity();
            privilege.FeatureId = privilegeDto.FeatureId;
            privilege.Id = privilegeDto.Id;
            privilege.ModulePrivileges = privilegeDto.ModulePrivileges.ForeachToEntity();
            privilege.Name = privilegeDto.Name;

            return privilege;
        }

        public static List<Dto.Privilege> ForeachToDto(this IList<Model.Privilege> privileges) {

            List<Dto.Privilege> privilegesDto = new List<Dto.Privilege>();

            foreach (var privilege in privileges)
            {
                privilegesDto.Add(privilege.ConvertToDto());
            }

            return privilegesDto;
        }

        public static List<Model.Privilege> ForeachToEntity(this IList<Dto.Privilege> privilegesDto)
        {

            List<Model.Privilege> privileges = new List<Model.Privilege>();

            foreach (var privilegeDto in privilegesDto)
            {
                privileges.Add(privilegeDto.ConvertToEntity());
            }

            return privileges;
        }
        
    }
}
