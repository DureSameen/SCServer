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
    public static class CustomerConverter
    {
        public static Dto.Customer ConvertToDto(this Model.Customer customer)
        {
            Dto.Customer customerDto = new Dto.Customer
            {
                Id = customer.Id,
                SecurityKey = customer.SecurityKey,
                Name= customer.Name ,
               EditionId =customer.EditionId,
                Enabled= customer.Enabled,
  
            };

            return customerDto;
        }

        public static Model.Customer ConvertToEntity(this Dto.Customer customerDto, Model.Customer customer = null)
        {
            if (customer == null)
                customer = new Model.Customer();

            customer.Id = customerDto.Id;
            customer.Name = customerDto.Name;
            customer.Enabled = customerDto.Enabled;
            customer.EditionId = customerDto.EditionId;
            customer.SecurityKey = customerDto.SecurityKey;
           

            return customer;
        }
    }

}
