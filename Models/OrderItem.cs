using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }=string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public int NumberItem { get; set; }
        public float Wieght { get; set; }
        public float CostOfWieght { get; set;}
        public string? Note { get; set; }
        
        public Order? Order { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
    }
}
