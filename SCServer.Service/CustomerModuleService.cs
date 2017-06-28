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
    public class CustomerModuleService : ICustomerModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.CustomerModule Get(Guid id)
        {
            var customermodule = _unitOfWork.CustomerModuleRepository.Get(id);

            if (customermodule == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Customer Module not found!", "Please provide correct ID.");

                return null;
            }

            return customermodule.ConvertToDto();
        }

        public IList<Core.Dto.CustomerModule> GetAll()
        {
            var customermodules = _unitOfWork.CustomerModuleRepository.GetAll();
            IList<Core.Dto.CustomerModule> customermodulesDto = new List<Core.Dto.CustomerModule>();

            foreach (var customermodule in customermodules)
            {
                customermodulesDto.Add(customermodule.ConvertToDto());
            }

            return customermodulesDto;
        }

        public Core.Dto.CustomerModule Create(Core.Dto.CustomerModule customermoduleDto)
        {
            var customermodule = customermoduleDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.CustomerModuleRepository.Create(customermodule);

            customermoduleDto = customermodule.ConvertToDto();

            _unitOfWork.Commit();

            return customermoduleDto;
        }

        public Core.Dto.CustomerModule Update(Core.Dto.CustomerModule customermoduleDto)
        {


            var existingCustomerDto = _unitOfWork.CustomerModuleRepository.Get(customermoduleDto.Id).ConvertToDto();

            existingCustomerDto.CustomerId = customermoduleDto.CustomerId;
            existingCustomerDto.FeatureId = customermoduleDto.FeatureId;
            existingCustomerDto.ModuleId = customermoduleDto.ModuleId;
            existingCustomerDto.PrivilegeId = customermoduleDto.PrivilegeId;
           
         
            _unitOfWork.BeginTransaction();

            var customermodule = _unitOfWork.CustomerModuleRepository.Update(existingCustomerDto.ConvertToEntity());

            _unitOfWork.Commit();

            customermoduleDto = customermodule.ConvertToDto();

            return customermoduleDto;
        }

        public void Delete(Guid id)
        {
            var customermodule = _unitOfWork.CustomerModuleRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.CustomerModuleRepository.Delete(customermodule);
            _unitOfWork.Commit();
        }
    }
}
