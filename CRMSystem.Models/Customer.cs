using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Models
{
    public class Customer
    {
        public Customer()
        {
            this.AddedOn = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public Status Status { get; set; }

        [MaxLength(20)]
        public int Phone { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        public DateTime AddedOn { get; set; }

        public ICollection<CustomerProduct> SalledProducts { get; set; } = new List<CustomerProduct>();
    }
}
