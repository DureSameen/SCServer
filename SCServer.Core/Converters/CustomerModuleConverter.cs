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
    public static class CustomerModuleConverter
    {
        public static Dto.CustomerModule ConvertToDto(this Model.CustomerModule customermodule)
        {
            Dto.CustomerModule customermoduleDto = new Dto.CustomerModule
            {
                Id = customermodule.Id,
                CustomerId= customermodule.CustomerId,
                FeatureId = customermodule.FeatureId,
                ModuleId= customermodule.ModuleId,
                PrivilegeId= customermodule.PrivilegeId
            }; 

            return customermoduleDto;
        }

        public static Model.CustomerModule ConvertToEntity(this Dto.CustomerModule customermoduleDto, Model.CustomerModule customermodule = null)
        {
            if (customermodule == null)
                customermodule = new Model.CustomerModule();

                customermodule.Id = customermoduleDto.Id;
                customermodule.CustomerId= customermoduleDto.CustomerId;
                customermodule.FeatureId = customermoduleDto.FeatureId;
                customermodule.ModuleId= customermoduleDto.ModuleId;
                customermodule.PrivilegeId = customermoduleDto.PrivilegeId;
           

            return customermodule;
        }
    }
}
