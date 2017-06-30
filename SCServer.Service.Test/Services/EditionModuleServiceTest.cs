using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 using SCServer.Service;
using SCServer.Service.Test.TestHelper;
using Moq;
using SCServer.Core.IRepository;
using System.Collections.Generic;
using SCServer.Core.IService;
using SCServer.Core.Dto;
using SCServer.Repository;
using SCServer.Core.Infrastructure;
using System.Linq;

 
namespace SCServer.Service.Test
{
    [TestClass]
    public class EditionModuleserviceTest : InMemoryDatabaseTest 
    {
        public EditionModuleserviceTest()
            : base()
          { }
       
      private Mock<IEditionModuleRepository> _mockRepository;
      private IEditionModuleservice _service;
      IUnitOfWork  _mockUnitWork;
      

      private Mock<ICustomerRepository> _mockCustomerRepository;
      private ICustomerService _customerservice;
      List<Core.Model.Customer> listCustomer;
 

      [TestInitialize]
      public void Initialize()
      {


          _mockRepository = new Mock<IEditionModuleRepository>();
          _mockCustomerRepository = new Mock<ICustomerRepository>();
          _mockUnitWork = new UnitOfWork(this, _mockCustomerRepository.Object ,_mockRepository.Object);


          _customerservice = new CustomerService(_mockUnitWork);
          _service = new EditionModuleservice(_mockUnitWork);
          listCustomer = new List<Core.Model.Customer>() {
           new   Core.Model.Customer() { Id = Guid.NewGuid (), Name = "XYZ Company" } 
          
          };
      }
 
      
 
 
      [TestMethod]
      public void Can_Add_Customer()
      {
          //Arrange
          Guid Id =  Guid.NewGuid ();
          Core.Model.Customer c = new Core.Model.Customer() {Id =Id, Name = "A Company" };
           Customer cdto = new  Customer() {Id =Id, Name = "A Company" };
           _mockCustomerRepository.Setup(m => m.Create(c)).Returns((Core.Model.Customer e) =>
          {
              e.Id = Id;
              return e;
          });
          
 
          //Act
           _customerservice.Create(cdto);
 
          //Assert
          Assert.AreEqual(Id, cdto.Id);
         
      }
 
 
    }
}
        
     

