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
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Module Get(Guid id)
        {
            var module = _unitOfWork.ModuleRepository.Get(id);

            if (module == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Module not found!", "Please provide correct ID.");

                return null;
            }

            return module.ConvertToDto();
        }

        public IList<Core.Dto.Module> GetAll()
        {
            var modules = _unitOfWork.ModuleRepository.GetAll();
            IList<Core.Dto.Module> modulesDto = new List<Core.Dto.Module>();

            foreach (var module in modules)
            {
                modulesDto.Add(module.ConvertToDto());
            }

            return modulesDto;
        }

        public Core.Dto.Module Create(Core.Dto.Module moduleDto)
        {
            var module = moduleDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.ModuleRepository.Create(module);

            moduleDto = module.ConvertToDto();

            _unitOfWork.Commit();

            return moduleDto;
        }

        public Core.Dto.Module Update(Core.Dto.Module moduleDto)
        {
             

            var existingModuleDto = _unitOfWork.ModuleRepository.Get(moduleDto.Id).ConvertToDto();

            existingModuleDto.Name = moduleDto.Name;
            existingModuleDto.TypeName = moduleDto.TypeName;  
            existingModuleDto.Enabled = moduleDto.Enabled;
            _unitOfWork.BeginTransaction();

            var module = _unitOfWork.ModuleRepository.Update(existingModuleDto.ConvertToEntity());

            _unitOfWork.Commit();

            moduleDto = module.ConvertToDto();

            return moduleDto;
        }

        public void Delete(Guid id)
        {
            var module = _unitOfWork.ModuleRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.ModuleRepository.Delete(module);
            _unitOfWork.Commit();
        }

        



    }
}
