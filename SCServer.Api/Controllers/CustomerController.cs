using SCServer.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SCServer.Api.Controllers
{
    public class CustomerController : ApiController
    {  
        
        
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<Core.Dto.Customer> Get()
        {
            IList<Core.Dto.Customer> customers = _customerService.GetAll();

            return customers;
        }

        public Core.Dto.Customer Get(Guid id)
        {
            return _customerService.Get(id);
        }

        public Core.Dto.Customer Post(Core.Dto.Customer customer)
        {
            return _customerService.Create(customer);
        }

        public Core.Dto.Customer Put(Core.Dto.Customer customer)
        {
            return _customerService.Update(customer);
        }

        public void Delete(Guid id)
        {
            _customerService.Delete(id);
        }


    }
}
