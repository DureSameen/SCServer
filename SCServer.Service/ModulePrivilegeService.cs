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

namespace SCServer.Service
{
    public class ModulePrivilegeService : IModulePrivilegeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModulePrivilegeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.ModulePrivilege Get(Guid id)
        {
            var ModulePrivilege = _unitOfWork.ModulePrivilegeRepository.Get(id);

            if (ModulePrivilege == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound,  "Module Privilege not found!", "Please provide correct ID.");

                return null;
            }

            return ModulePrivilege.ConvertToDto();
        }

        public IList<Core.Dto.ModulePrivilege> GetAll()
        {
            var ModulePrivileges = _unitOfWork.ModulePrivilegeRepository.GetAll();
            IList<Core.Dto.ModulePrivilege> ModulePrivilegesDto = new List<Core.Dto.ModulePrivilege>();

            foreach (var ModulePrivilege in ModulePrivileges)
            {
                ModulePrivilegesDto.Add(ModulePrivilege.ConvertToDto());
            }

            return ModulePrivilegesDto;
        }

        public Core.Dto.ModulePrivilege Create(Core.Dto.ModulePrivilege ModulePrivilegeDto)
        {
            var ModulePrivilege = ModulePrivilegeDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.ModulePrivilegeRepository.Create(ModulePrivilege);

            ModulePrivilegeDto = ModulePrivilege.ConvertToDto();

            _unitOfWork.Commit();

            return ModulePrivilegeDto;
        }

        public Core.Dto.ModulePrivilege Update(Core.Dto.ModulePrivilege ModulePrivilegeDto)
        {


            var existingModulePrivilege = _unitOfWork.ModulePrivilegeRepository.Get(ModulePrivilegeDto.Id).ConvertToDto();

            existingModulePrivilege.CustomerId = ModulePrivilegeDto.CustomerId;
            existingModulePrivilege.FeatureId = ModulePrivilegeDto.FeatureId;
            existingModulePrivilege.ModuleId = ModulePrivilegeDto.ModuleId;
            existingModulePrivilege.PrivilegeId = ModulePrivilegeDto.PrivilegeId;
           
         
            _unitOfWork.BeginTransaction();

            var ModulePrivilege = _unitOfWork.ModulePrivilegeRepository.Update(existingModulePrivilege.ConvertToEntity());

            _unitOfWork.Commit();

            ModulePrivilegeDto = ModulePrivilege.ConvertToDto();

            return ModulePrivilegeDto;
        }

        public void Delete(Guid id)
        {
            var ModulePrivilege = _unitOfWork.ModulePrivilegeRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.ModulePrivilegeRepository.Delete(ModulePrivilege);
            _unitOfWork.Commit();
        }
    }
}
