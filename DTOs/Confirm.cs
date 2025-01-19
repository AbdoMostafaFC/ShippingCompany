using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.DTOs
{
    public class Confirm
    {
        [Required]
        public int OrderId { get; set; }
        [Required]

        public string Code { get; set; }
    }
}
