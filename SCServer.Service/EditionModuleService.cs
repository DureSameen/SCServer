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
    public class EditionModuleService : IEditionModuleservice
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditionModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.EditionModule Get(Guid id)
        {
            var EditionModule = _unitOfWork.EditionModuleRepository.Get(id);

            if (EditionModule == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Customer Module not found!", "Please provide correct ID.");

                return null;
            }

            return EditionModule.ConvertToDto();
        }

        public IList<Core.Dto.EditionModule> GetAll()
        {
            var EditionModules = _unitOfWork.EditionModuleRepository.GetAll();
            IList<Core.Dto.EditionModule> EditionModulesDto = new List<Core.Dto.EditionModule>();

            foreach (var EditionModule in EditionModules)
            {
                EditionModulesDto.Add(EditionModule.ConvertToDto());
            }

            return EditionModulesDto;
        }

        public Core.Dto.EditionModule Create(Core.Dto.EditionModule EditionModuleDto)
        {
            var EditionModule = EditionModuleDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.EditionModuleRepository.Create(EditionModule);

            EditionModuleDto = EditionModule.ConvertToDto();

            _unitOfWork.Commit();

            return EditionModuleDto;
        }

        public Core.Dto.EditionModule Update(Core.Dto.EditionModule EditionModuleDto)
        {


            var existingCustomerDto = _unitOfWork.EditionModuleRepository.Get(EditionModuleDto.Id).ConvertToDto();

            existingCustomerDto.CustomerId = EditionModuleDto.CustomerId;
            existingCustomerDto.FeatureId = EditionModuleDto.FeatureId;
            existingCustomerDto.ModuleId = EditionModuleDto.ModuleId;
            existingCustomerDto.PrivilegeId = EditionModuleDto.PrivilegeId;
           
         
            _unitOfWork.BeginTransaction();

            var EditionModule = _unitOfWork.EditionModuleRepository.Update(existingCustomerDto.ConvertToEntity());

            _unitOfWork.Commit();

            EditionModuleDto = EditionModule.ConvertToDto();

            return EditionModuleDto;
        }

        public void Delete(Guid id)
        {
            var EditionModule = _unitOfWork.EditionModuleRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EditionModuleRepository.Delete(EditionModule);
            _unitOfWork.Commit();
        }
    }
}
