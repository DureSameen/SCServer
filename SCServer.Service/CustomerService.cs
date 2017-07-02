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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Customer Get(Guid id)
        {
            var customer = _unitOfWork.CustomerRepository.Get(id);

            if (customer == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Customer not found!", "Please provide correct ID.");

                return null;
            }

            return customer.ConvertToDto();
        }

        public IList<Core.Dto.Customer> GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll();
            IList<Core.Dto.Customer> customersDto = new List<Core.Dto.Customer>();

            foreach (var customer in customers)
            {
                customersDto.Add(customer.ConvertToDto());
            }

            return customersDto;
        }

        public Core.Dto.Customer Create(Core.Dto.Customer customerDto)
        {
            var customer = customerDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.CustomerRepository.Create(customer);

            customerDto = customer.ConvertToDto();

            _unitOfWork.Commit();

            return customerDto;
        }

        public Core.Dto.Customer Update(Core.Dto.Customer customerDto)
        {
             

            var existingCustomerDto = _unitOfWork.CustomerRepository.Get(customerDto.Id).ConvertToDto();

            existingCustomerDto.Name = customerDto.Name;
            existingCustomerDto.SecurityKey = customerDto.SecurityKey;
            existingCustomerDto.Enabled = customerDto.Enabled;
            _unitOfWork.BeginTransaction();

            var customer = _unitOfWork.CustomerRepository.Update(existingCustomerDto.ConvertToEntity());

            _unitOfWork.Commit();

            customerDto = customer.ConvertToDto();

            return customerDto;
        }

        public void Delete(Guid id)
        {
            var customer = _unitOfWork.CustomerRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.CustomerRepository.Delete(customer);
            _unitOfWork.Commit();
        }

        public Core.Dto.Customer GetEditionUrl(Guid secretkey)
        {

            var customer = _unitOfWork.CustomerRepository.GetBySecretKey(secretkey);



            var allmodules= _unitOfWork.EditionModuleRepository.GetByEditionId(customer.EditionId);

            return customer.ConvertToDto ();
        
        }
    }
}
