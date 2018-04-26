using CRMSystem.Services.Models;

namespace CRMSystem.Services
{
    public interface ICustomerService 
    {
        CustomerServiceModel Info(string name);
    }
}