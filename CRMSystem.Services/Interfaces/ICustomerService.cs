using CRMSystem.Services.Models;

namespace CRMSystem.Implementations.Services
{
    public interface ICustomerService 
    {
        CustomerServiceModel Info(string name);
    }
}