using System;
using System.Collections.Generic;

namespace CRMSystem.Models
{
    public class Customer
    {
        private ICollection<Product> salledProducts;

        public Customer()
        {
            this.salledProducts = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public DateTime AddedOn { get; set; }

        public virtual ICollection<Product> SalledProducts
        {
            get { return this.salledProducts; }
            set { this.salledProducts = value; }
        }
    }
}
