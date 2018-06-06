using System;
using System.Collections.Generic;
using CRMSystem.Models;

namespace CRMSystem.DTOModels.Models
{
    [Serializable]
    public class CustomerDTO
    {
        public string Company { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public List<CustomerProduct> SalledProducts { get; set; }
    }
}
