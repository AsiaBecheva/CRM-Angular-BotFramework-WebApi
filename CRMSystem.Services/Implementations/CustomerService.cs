using System;
using System.Linq;
using CRMSystem.Data.Repository;
using CRMSystem.Implementations.Services;
using CRMSystem.Services.Models;

namespace CRMSystem.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork db;

        public CustomerService(IUnitOfWork db)
        {
            this.db = db;
        }

        public CustomerServiceModel Info(string name)
        {
            var customer = this.db.Customers.All()
            .Where(x => x.Name == name)
            .FirstOrDefault();

            CustomerServiceModel model = new CustomerServiceModel
            {
                AddedOn = DateTime.Now,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone,
                Status = customer.Status,
                Id = customer.Id,
                SalledProducts = customer.SalledProducts
            };

            return model;
        }
    }
}
