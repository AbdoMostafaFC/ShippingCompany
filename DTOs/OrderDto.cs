using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.DTOs
{
    public class OrderDto
    {
        [Required]
        public string SenderName { get; set; } = string.Empty;
        [Required]
        public string SenderCity { get; set; } = string.Empty;
        [Required]
        public string SenderPhone { get; set; } = string.Empty;
        [Required]
        public string SenderResidenceNumber { get; set; } = string.Empty;
        public string ReciverName { get; set; } = string.Empty;
        [Required]
        public string ReciverRegion { get; set; } = string.Empty;
        [Required]
        public string ReciverCity { get; set; } = string.Empty;
        public string ReciverStreet { get; set; } = string.Empty;
        [Required]
        public string ReciverPhone { get; set; } = string.Empty;
        [Required]
        public IFormFile ProductIamge { get; set; }

    }
}
