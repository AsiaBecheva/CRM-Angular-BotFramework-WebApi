using System;
using CRMSystem.Data.Repository;
using CRMSystem.DTOModels.Models;
using CRMSystem.Models;
using CRMSystem.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CRMSystem.Tests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void Get_ReturnsNotFound_ForInvalidCustomerId()
        {
            // Arrange
            int testId = 5;
            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.GetById(testId))
                .Returns((Customer)null);
            var sut = new CustomersController(mockRepo.Object);

            // Act 
            var result = sut.Get(testId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Get_ReturnsOk_ForValidCustomerId()
        {
            // Arrange
            int testId = 5;
            var customer = new Customer
            {
                Id = 5,
                AddedOn = DateTime.Now,
                Address = "Some address",
                Company = "Some company",
                Email = "asia@gmail.com",
                FirstName = "Asya",
                LastName = "Becheva",
                Phone = "0888998899",
                Status = Status.active,
                Username = "asyaB"
            };

            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.Customers.GetById(testId))
                .Returns((customer));
            var sut = new CustomersController(mockRepo.Object);

            // Act 
            var result = sut.Get(testId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ReturnsBadRequest_GivenRequiredModel()
        {
            // Arrange
            var mockRepo = new Mock<IUnitOfWork>();
            var sut = new CustomersController(mockRepo.Object);
            sut.ModelState.AddModelError("error", "some error");

            // Act
            var result = sut.Post(model: null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        //[Fact]
        //public void Post_VerifyThatResultIsOfTypeCreatedResultInCaseOfException()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<IUnitOfWork>();
        //    mockRepo.Setup(x => x.Customers.Add(It.IsAny<Customer>())).Verifiable();
        //    var sut = new CustomersController(mockRepo.Object);

        //    // Act
        //    var result = sut.Post(new CustomerDTO());

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        [Fact]
        public void Post_VerifyThatModelStateIsValid()
        {
            // Arrange
            var customer = new CustomerDTO
            {
                Address = "Some address",
                Company = "Some company",
                Email = "asia@gmail.com",
                FirstName = "Asya",
                LastName = "Becheva",
                Phone = "0888998899",
                Status = Status.active,
                Username = "asyaB",
            };

            var mockRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(x => x.Customers.Add(It.IsAny<Customer>())).Verifiable();
            var sut = new CustomersController(mockRepo.Object);

            // Act
            var result = sut.Post(customer);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
