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

        public string GetEditionUrl(Guid secretkey)
        {

            var customer = _unitOfWork.CustomerRepository.GetBySecretKey(secretkey);

            Guid editionid= customer.EditionId.Value;

            //dir on webapi project where all editions zip files will be present.

            var dir= HttpContext.Current.Server.MapPath("~/Editions/");
            
            //dir of a edition 

            var editionid_dir =dir+ editionid ;
            var editition_modules_dir = editionid_dir + "//Modules";
            
            //dir where modules files are uploaded 


            var modulesdir = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Modules/")  );

            if (!System.IO.Directory.Exists(editionid_dir))
            {
                System.IO.Directory.CreateDirectory(editionid_dir);
                System.IO.Directory.CreateDirectory(editition_modules_dir);
                var allmodules = _unitOfWork.EditionModuleRepository.GetByEditionId(editionid);


                EditionInfo edition_info = new EditionInfo();

                foreach (var module in allmodules)
                {
                    ModuleVm module_vm = new ModuleVm();

                    string mdouleFile = module.Module.TypeName + ".dll";

                    module_vm.TypeName = mdouleFile;
                    module_vm.Name = module.Module.Name;

                    string mdouleFilepath = System.IO.Path.Combine(modulesdir, mdouleFile); ;
                    string destinationFilepath = System.IO.Path.Combine(editition_modules_dir, mdouleFile); ;

                    if (System.IO.File.Exists(mdouleFilepath))
                    { System.IO.File.Copy(mdouleFilepath, destinationFilepath, true); }


                    edition_info.Modules.Add(module_vm);

                }

                //create customer modules  information json file.
                string startPath = editionid_dir;

                var json = JsonHelper.Serialize(edition_info);

                System.IO.File.WriteAllText(startPath + "//edition_info.json", json);

               
                string zipPath = dir + editionid + ".zip";

                ZipFile.CreateFromDirectory(startPath, zipPath);

                 

            }

            string baseUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";

            return baseUrl+"Editions/" + editionid+".zip";
        
        }



    }
}
