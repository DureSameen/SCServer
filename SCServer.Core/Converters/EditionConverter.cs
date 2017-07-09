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
    public static class EditionConverter
    {
        public static Dto.Edition ConvertToDto(this Model.Edition edition, bool include_children=false)
        {
            Dto.Edition editionDto = new Dto.Edition
            {
                Enabled = edition.Enabled,
                Id = edition.Id,

                ModulePrivileges = (include_children) ? edition.ModulePrivileges.ForeachToDto() : new List<Dto.ModulePrivilege>(),
                Sections = (include_children) ? edition.Sections.ForeachToDto() : new List<Dto.Section>(),
                Name = edition.Name,
                 Sort_Key=edition.Sort_Key  
            };

            return editionDto;
        }

        public static Model.Edition ConvertToEntity(this Dto.Edition editionDto, Model.Edition edition = null) {
            if (edition == null)
            {
                edition = new Model.Edition();
            }

            edition.Enabled = editionDto.Enabled;
            edition.Id = editionDto.Id;
            edition.ModulePrivileges = editionDto.ModulePrivileges.ForeachToEntity();
            edition.Name = editionDto.Name;
            edition.Sort_Key = editionDto.Sort_Key;

            return edition;
        }
    }
}
