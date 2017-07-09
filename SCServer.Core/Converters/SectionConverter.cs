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
    public static class SectionConverter
    {
        public static Dto.Section ConvertToDto(this Model.Section section)
        {
            Dto.Section sectionDto = new Dto.Section
            {
                Enabled = section.Enabled,
                Id = section.Id,
                EditionId= section.EditionId ,
                Edition= (section.Edition!=null) ? section.Edition.ConvertToDto():null,
                Name = section.Name,
                Sort_Key=section.Sort_Key ,
                Modules = (section.Modules != null) ? section.Modules.ForeachToDto(): null,
            };

            return sectionDto;
        }

        public static Model.Section ConvertToEntity(this Dto.Section sectionDto, Model.Section section = null) {
            if (section == null)
            {
                section = new Model.Section();
            }

            section.Enabled = sectionDto.Enabled;
            section.Id = sectionDto.Id;
            section.EditionId= sectionDto.EditionId ;
            if (sectionDto.Edition!=null)
            section.Edition = sectionDto.Edition.ConvertToEntity();
            section.Name = sectionDto.Name;
            section.Sort_Key = sectionDto.Sort_Key;

            return section;
        }


        public static List<Dto.Section> ForeachToDto(this IList<Model.Section> Sections)
        {

            List<Dto.Section> SectionsDto = new List<Dto.Section>();

            foreach (var section in Sections)
            {
                SectionsDto.Add(section.ConvertToDto());
            }

            return SectionsDto;
        }

        public static List<Model.Section> ForeachToEntity(this IList<Dto.Section> SectionsDto)
        {

            List<Model.Section> sections = new List<Model.Section>();

            foreach (var sectionDto in SectionsDto)
            {
                sections.Add(sectionDto.ConvertToEntity());
            }

            return sections;
        }
    }
}
