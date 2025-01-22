using ShippingCompany.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.DTOs
{
    public class OrderItemDTO
    {
       
        [Required]
        public string ItemName { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public int NumberItem { get; set; }
        public float Wieght { get; set; }
        public float CostOfWieght { get; set; }
        public string? Note { get; set; }
        
    }
}
