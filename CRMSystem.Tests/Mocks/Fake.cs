using System;
using System.Collections.Generic;
using CRMSystem.DTOModels.Models;
using CRMSystem.Models;

namespace CRMSystem.Tests.Mocks
{
    public class FakeData
    {
        public FakeData()
        {
            this.CreateFakeCustomers();
        }

        public ICollection<Customer> FakeCustomers { get; set; }

        public CustomerDTO CustomerDTO
        {
            get
            {
                return new CustomerDTO
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
            }
        }

        public Customer Customer
        {
            get
            {
                return new Customer
                {
                    Id = 10,
                    AddedOn = DateTime.Now,
                    Address = "Some address",
                    Company = "Some company",
                    Email = "asia@gmail.com",
                    FirstName = "Asya",
                    LastName = "Becheva",
                    Phone = "0888998899",
                    Status = Status.active,
                    Username = "asyaB",
                };
            }
        }

        private void CreateFakeCustomers()
        {
            this.FakeCustomers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Asya", LastName = "Becheva", Address = "ul. Marica", Email = "asiabecheva@gmail.com", Company = "mycompany", Phone = "0884545454", Status = Status.active, AddedOn = DateTime.Now, Username = "asyaB" },
                new Customer { Id = 2, FirstName = "Ivan", LastName = "Ivanova", Address = "ul. Dunav", Email = "ivanivanov@gmail.com", Company = "second company", Phone = "0884112233", Status = Status.inactive, AddedOn = DateTime.Now, Username = "ivanI" },
                new Customer { Id = 3, FirstName = "Petar", LastName = "Petrov", Address = "ul. Iskar", Email = "petarpetrov@gmail.com", Company = "another company", Phone = "0888778877", Status = Status.active, AddedOn = DateTime.Now, Username = "petarP" },
                new Customer { Id = 4, FirstName = "Georgi", LastName = "Georgiev", Address = "ul. Amazonka", Email = "goshogeorgiev@gmail.com", Company = "goshos company", Phone = "0887878787", Status = Status.inactive, AddedOn = DateTime.Now, Username = "goshoG" },
            };
        }


    }
}
