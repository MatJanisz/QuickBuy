using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.DA.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerEmail { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
    }
}
