using System.Linq;
using AutoMapper.QueryableExtensions;
using CRMSystem.Data;
using CRMSystem.Data.Repository;
using CRMSystem.Services.Models;

namespace CRMSystem.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CRMDbContext db;

        public CustomerService(CRMDbContext db)
        {
            this.db = db;
        }

        public CustomerServiceModel Info(string name)
            => this.db.Customers
            .Where(x => x.Name == name)
            .ProjectTo<CustomerServiceModel>()
            .FirstOrDefault();
    }
}
