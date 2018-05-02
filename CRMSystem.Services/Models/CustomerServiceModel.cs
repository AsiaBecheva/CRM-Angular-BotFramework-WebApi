﻿using System;
using System.Collections.Generic;
using AutoMapper;
using CRMSystem.Models;
using CRMSystem.Services.Mapping;

namespace CRMSystem.Services.Models
{
    public class CustomerServiceModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Status Status { get; set; }
        
        public int Phone { get; set; }
        
        public string Email { get; set; }

        public DateTime AddedOn { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Customer, CustomerServiceModel>();
    }
}