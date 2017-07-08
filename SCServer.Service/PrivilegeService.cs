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
    public class PrivilegeService : IPrivilegeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrivilegeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Privilege Get(Guid id)
        {
            var privilege = _unitOfWork.PrivilegeRepository.Get(id);

            if (privilege == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Privilege not found!", "Please provide correct ID.");

                return null;
            }

            return privilege.ConvertToDto();
        }

        public IList<Core.Dto.Privilege> GetAll()
        {
            var privileges = _unitOfWork.PrivilegeRepository.GetAll();
            IList<Core.Dto.Privilege> privilegesDto = new List<Core.Dto.Privilege>();

            foreach (var privilege in privileges)
            {
                privilegesDto.Add(privilege.ConvertToDto());
            }

            return privilegesDto;
        }

        public Core.Dto.Privilege Create(Core.Dto.Privilege privilegeDto)
        {
            var privilege = privilegeDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.PrivilegeRepository.Create(privilege);

            privilegeDto = privilege.ConvertToDto();

            _unitOfWork.Commit();

            return privilegeDto;
        }

        public Core.Dto.Privilege Update(Core.Dto.Privilege privilegeDto)
        {
             

            var existingPrivilegeDto = _unitOfWork.PrivilegeRepository.Get(privilegeDto.Id).ConvertToDto();

            existingPrivilegeDto.Name = privilegeDto.Name;
            existingPrivilegeDto.FeatureId = privilegeDto.FeatureId;  
            existingPrivilegeDto.Enabled = privilegeDto.Enabled;
            _unitOfWork.BeginTransaction();

            var privilege = _unitOfWork.PrivilegeRepository.Update(existingPrivilegeDto.ConvertToEntity());

            _unitOfWork.Commit();

            privilegeDto = privilege.ConvertToDto();

            return privilegeDto;
        }

        public void Delete(Guid id)
        {
            var privilege = _unitOfWork.PrivilegeRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.PrivilegeRepository.Delete(privilege);
            _unitOfWork.Commit();
        }

        



    }
}
