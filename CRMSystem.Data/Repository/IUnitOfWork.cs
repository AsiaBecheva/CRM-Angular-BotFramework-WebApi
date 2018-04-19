using CRMSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Data.Repository
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        IRepository<Customer> Customers { get; }

        IRepository<Product> Products { get; }

        IRepository<User> Users { get; }

        void Dispose();

        int SaveChanges();
    }
}
