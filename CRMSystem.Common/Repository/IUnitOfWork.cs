using CRMSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Data.Repository
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }

        IRepository<Customer> Customers { get; }

        IRepository<Product> Products { get; }

        void Dispose();

        int SaveChanges();
    }
}
