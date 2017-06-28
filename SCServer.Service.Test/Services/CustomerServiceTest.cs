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
    public class CustomerServiceTest : InMemoryDatabaseTest 
    {
        public CustomerServiceTest()
            : base()
          { }
       
      private Mock<ICustomerRepository> _mockRepository;
      private ICustomerService _service;
      IUnitOfWork  _mockUnitWork;
      List<Core.Model.Customer> listCustomer;
 
      [TestInitialize]
      public void Initialize()
      {


          _mockRepository = new Mock<ICustomerRepository>();
       _mockUnitWork = new UnitOfWork(this, _mockRepository.Object);


          _service = new CustomerService(_mockUnitWork );
          listCustomer = new List<Core.Model.Customer>() {
           new   Core.Model.Customer() { Id = Guid.NewGuid (), Name = "XYZ Company" },
           new   Core.Model.Customer() { Id = Guid.NewGuid (), Name = "ABC Company" },
           new   Core.Model.Customer() { Id = Guid.NewGuid (), Name = "PLY Company" }
          };
      }
 
      [TestMethod]
      public void Customer_Get_All()
      {
          //Arrange
          _mockRepository.Setup(x => x.GetAll()).Returns(listCustomer.AsQueryable());
 
          //Act
          List<Customer> results = _service.GetAll() as List<Customer>;
 
          //Assert
          Assert.IsNotNull(results);
          Assert.AreEqual(3, results.Count);
      }
 
 
      [TestMethod]
      public void Can_Add_Customer()
      {
          //Arrange
          Guid Id =  Guid.NewGuid ();
          Core.Model.Customer c = new Core.Model.Customer() {Id =Id, Name = "A Company" };
           Customer cdto = new  Customer() {Id =Id, Name = "A Company" };
          _mockRepository.Setup(m => m.Create(c)).Returns( (   Core.Model.Customer e) =>
          {
              e.Id = Id;
              return e;
          });
          
 
          //Act
          _service.Create(cdto);
 
          //Assert
          Assert.AreEqual(Id, cdto.Id);
         
      }
 
 
    }
}
        
     

