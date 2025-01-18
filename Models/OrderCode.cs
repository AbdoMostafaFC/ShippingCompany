using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.Models
{
    public class OrderCode
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
