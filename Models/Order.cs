using ShippingCompany.StaticDataSeeding;
using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.Models
{
    public class Order
    {

        public int Id { get; set; }
        [Required]

        public string CustomerName { get; set; }=string.Empty;
        public string? Address { get; set; }
        [Required]

        public string Phone { get; set; }=string.Empty;
        [Required]

        public string UniqueNumber { get; set; }=string.Empty;
        [Required]
        public string ProducImage { get; set; }=string.Empty;

        public string Status {  get; set; }=OrderStatus.CreateStatus;


    }
}
