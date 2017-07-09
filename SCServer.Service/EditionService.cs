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
    public class EditionService : IEditionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Dto.Edition Get(Guid id)
        {
            var edition = _unitOfWork.EditionRepository.Get(id);

            if (edition == null)
            {
                ExceptionHelper.ThrowApiException(HttpStatusCode.NotFound, "Edition not found!", "Please provide correct ID.");

                return null;
            }

            return edition.ConvertToDto();
        }

        public IList<Core.Dto.Edition> GetAll()
        {
            var editions = _unitOfWork.EditionRepository.GetAll();
            IList<Core.Dto.Edition> editionsDto = new List<Core.Dto.Edition>();

            foreach (var edition in editions)
            {
                editionsDto.Add(edition.ConvertToDto());
            }

            return editionsDto.OrderBy (e=>e.Sort_Key).ToList ();
        }

        public Core.Dto.Edition Create(Core.Dto.Edition editionDto)
        {
            var edition = editionDto.ConvertToEntity();

            _unitOfWork.BeginTransaction();
            _unitOfWork.EditionRepository.Create(edition);

            editionDto = edition.ConvertToDto();

            _unitOfWork.Commit();

            return editionDto;
        }

        public Core.Dto.Edition Update(Core.Dto.Edition editionDto)
        {
             

            var existingEditionDto = _unitOfWork.EditionRepository.Get(editionDto.Id).ConvertToDto();

            existingEditionDto.Name = editionDto.Name;
            existingEditionDto.Sort_Key = editionDto.Sort_Key;  
            existingEditionDto.Enabled = editionDto.Enabled;
            _unitOfWork.BeginTransaction();

            var edition = _unitOfWork.EditionRepository.Update(existingEditionDto.ConvertToEntity());

            _unitOfWork.Commit();

            editionDto = edition.ConvertToDto();

            return editionDto;
        }

        public void Delete(Guid id)
        {
            var edition = _unitOfWork.EditionRepository.Get(id);

            _unitOfWork.BeginTransaction();
            _unitOfWork.EditionRepository.Delete(edition);
            _unitOfWork.Commit();
        }

        



    }
}
