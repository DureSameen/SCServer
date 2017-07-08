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
    public class SectionModulesService : ISectionModulesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionModulesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.SectionModules Get(Guid id)
        {
            var sectionModules = _unitOfWork.SectionModulesRepository.Get(id);

            if (sectionModules == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "SectionModules not found!", "Please provide correct ID.");

                return null;
            }

            return sectionModules.ConvertToDto();
        }

        public IList<Core.Dto.SectionModules> GetAll()
        {
            var sectionModuless = _unitOfWork.SectionModulesRepository.GetAll();
            IList<Core.Dto.SectionModules> sectionModulessDto = new List<Core.Dto.SectionModules>();

            foreach (var sectionModules in sectionModuless)
            {
                sectionModulessDto.Add(sectionModules.ConvertToDto());
            }

            return sectionModulessDto;
        }

        public Core.Dto.SectionModules Create(Core.Dto.SectionModules sectionModulesDto)
        {
            var sectionModules = sectionModulesDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.SectionModulesRepository.Create(sectionModules);

            sectionModulesDto = sectionModules.ConvertToDto();

            _unitOfWork.Commit();

            return sectionModulesDto;
        }

        public Core.Dto.SectionModules Update(Core.Dto.SectionModules sectionModulesDto)
        {
             

            var existingSectionModulesDto = _unitOfWork.SectionModulesRepository.Get(sectionModulesDto.Id).ConvertToDto();
            existingSectionModulesDto.SectionId = sectionModulesDto.SectionId;

            existingSectionModulesDto.ModuleId = sectionModulesDto.ModuleId;
            existingSectionModulesDto.Sort_Key = sectionModulesDto.Sort_Key;  
            existingSectionModulesDto.Enabled = sectionModulesDto.Enabled;
           
           
            _unitOfWork.BeginTransaction();

            var sectionModules = _unitOfWork.SectionModulesRepository.Update(existingSectionModulesDto.ConvertToEntity());

            _unitOfWork.Commit();

            sectionModulesDto = sectionModules.ConvertToDto();

            return sectionModulesDto;
        }

        public void Delete(Guid id)
        {
            var sectionModules = _unitOfWork.SectionModulesRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.SectionModulesRepository.Delete(sectionModules);
            _unitOfWork.Commit();
        }

        



    }
}
