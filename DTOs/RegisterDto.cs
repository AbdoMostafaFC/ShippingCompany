using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.DTOs
{
    public class RegisterDto
    {
        
            [EmailAddress]
            [Required]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        
    }
}
