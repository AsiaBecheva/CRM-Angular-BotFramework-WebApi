using System;
using System.Collections.Generic;
using CRMSystem.Models;

namespace CRMSystem.DTOModels.Models
{
    [Serializable]
    public class CustomerDTO
    {
        public string Name { get; set; }

        public Status Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; }
    }
}
