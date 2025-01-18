using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.DTOs
{
    public class OrderDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string? Address { get; set; }
        [Required]

        public string Phone { get; set; } = string.Empty;
        [Required]

        public string UniqueNumber { get; set; } = string.Empty;
        [Required]
        public IFormFile ProductIamge { get; set; }

    }
}
