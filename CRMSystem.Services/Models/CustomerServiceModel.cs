using System;
using System.Collections.Generic;
using AutoMapper;
using CRMSystem.Common.Mapping;
using CRMSystem.Models;

namespace CRMSystem.Services.Models
{
    public class CustomerServiceModel: IMapFrom<Customer>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Status Status { get; set; }
        
        public int Phone { get; set; }
        
        public string Email { get; set; }

        public DateTime AddedOn { get; set; }

        public IEnumerable<string> SalledProducts { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Customer, CustomerServiceModel>();
    }
}
