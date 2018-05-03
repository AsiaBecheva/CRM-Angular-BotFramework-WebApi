using System;
using System.Collections.Generic;
using AutoMapper;
using CRMSystem.Models;

namespace CRMSystem.Services.Models
{
    [Serializable]
    public class CustomerServiceModel
    {
        public string Name { get; set; }

        public Status Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; }
    }
}
