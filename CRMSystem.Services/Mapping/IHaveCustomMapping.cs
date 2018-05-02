using AutoMapper;

namespace CRMSystem.Services.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
