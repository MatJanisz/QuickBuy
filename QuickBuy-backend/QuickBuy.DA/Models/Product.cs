using QuickBuy.DA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuickBuy.DA.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string OwnerId { get; set; }
        public User User { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ImageSource { get; set; }

        public Category Category { get; set; }

        public ICollection<UserProduct> UserProducts { get; set; }
    }
}
