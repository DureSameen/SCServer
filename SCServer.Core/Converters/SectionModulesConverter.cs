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
    public static class SectionModulesConverter
    {
        public static Dto.SectionModules ConvertToDto(this Model.SectionModules sectionModules)
        {
            Dto.SectionModules sectionModulesDto = new Dto.SectionModules
            {
             
                Id = sectionModules.Id,
                Module = sectionModules.Module.ConvertToDto(),
                ModuleId = sectionModules.ModuleId,
                Section=sectionModules.Section.ConvertToDto (),
                Enabled=sectionModules.Enabled ,
                Sort_Key = sectionModules.Sort_Key 
            };

            return sectionModulesDto;
        }

        public static Model.SectionModules ConvertToEntity(this Dto.SectionModules sectionModulesDto, Model.SectionModules sectionModules = null) {

            if (sectionModules == null)
            {
                sectionModules = new Model.SectionModules();
            }

            
            sectionModules.Id = sectionModulesDto.Id;
            sectionModules.Module = sectionModulesDto.Module.ConvertToEntity();
            sectionModules.ModuleId = sectionModulesDto.ModuleId;
            sectionModules.Section=sectionModulesDto.Section.ConvertToEntity();
            sectionModules.Enabled=sectionModulesDto.Enabled ;
            sectionModules.Sort_Key = sectionModulesDto.Sort_Key;

            return sectionModules;
        }

        
    }
}
