using AutoMapper;
using CRMSystem.Services.Implementations;

namespace CRMSystem.Services.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<ICustomerService, CustomerService>();
        }
    }
}
