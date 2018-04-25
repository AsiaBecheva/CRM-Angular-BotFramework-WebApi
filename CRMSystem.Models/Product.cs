﻿using System.ComponentModel.DataAnnotations;

namespace CRMSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Info { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
