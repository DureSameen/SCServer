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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Section Get(Guid id)
        {
            var section = _unitOfWork.SectionRepository.Get(id);

            if (section == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Section not found!", "Please provide correct ID.");

                return null;
            }

            return section.ConvertToDto();
        }

        public IList<Core.Dto.Section> GetAll()
        {
            var sections = _unitOfWork.SectionRepository.GetAll();
            IList<Core.Dto.Section> sectionsDto = new List<Core.Dto.Section>();

            foreach (var section in sections)
            
            { 
                section.Edition = _unitOfWork.EditionRepository.Get(section.EditionId.Value);

                sectionsDto.Add(section.ConvertToDto());
            }

            return sectionsDto.OrderBy(s => s.Edition.Sort_Key).OrderBy(s => s.Sort_Key).ToList();
        }
        public IList<Core.Dto.Section> GetAllbyEditionId(Guid EditionId)
        {
            var sections = _unitOfWork.SectionRepository.GetAllbyEditionId(EditionId);

            IList<Core.Dto.Section> sectionsDto = new List<Core.Dto.Section>();

            foreach (var section in sections)
            {
                section.Edition = _unitOfWork.EditionRepository.Get(section.EditionId.Value);

                sectionsDto.Add(section.ConvertToDto());
            }

            return sectionsDto.OrderBy(s => s.Edition.Sort_Key).OrderBy(s => s.Sort_Key).ToList();
        }
        public Core.Dto.Section Create(Core.Dto.Section sectionDto)
        {
            var section = sectionDto.ConvertToEntity();
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.SectionRepository.Create(section);

                sectionDto = section.ConvertToDto();

                _unitOfWork.Commit();

                return sectionDto;
            }
            catch
            { return sectionDto; }
        }

        public Core.Dto.Section Update(Core.Dto.Section sectionDto)
        {
             

            var existingSectionDto = _unitOfWork.SectionRepository.Get(sectionDto.Id).ConvertToDto();

            existingSectionDto.Name = sectionDto.Name;
            existingSectionDto.Sort_Key = sectionDto.Sort_Key;  
            existingSectionDto.Enabled = sectionDto.Enabled;
            existingSectionDto.EditionId = sectionDto.EditionId;
           
            _unitOfWork.BeginTransaction();

            var section = _unitOfWork.SectionRepository.Update(existingSectionDto.ConvertToEntity());

            _unitOfWork.Commit();

            sectionDto = section.ConvertToDto();

            return sectionDto;
        }

        public void Delete(Guid id)
        {
            var section = _unitOfWork.SectionRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.SectionRepository.Delete(section);
            _unitOfWork.Commit();
        }

        



    }
}
