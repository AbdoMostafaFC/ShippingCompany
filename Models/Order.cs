using ShippingCompany.StaticDataSeeding;
using System.ComponentModel.DataAnnotations;

namespace ShippingCompany.Models
{
    public class Order
    {

        public int Id { get; set; }
        [Required]

        public string SenderName { get; set; }=string.Empty;
        [Required]
        public string SenderCity { get; set; }=string.Empty;
        [Required]
        public string SenderPhone { get; set; }=string.Empty;
        [Required]
        public string SenderResidenceNumber { get; set; }=string.Empty;
        public string ReciverName { get; set; } = string.Empty;
        [Required]
        public string ReciverRegion { get; set; }=string.Empty;
        [Required]
        public string ReciverCity { get; set; }=string.Empty;
        public string ReciverStreet { get; set; }=string.Empty;
        [Required]
        public string ReciverPhone { get; set; }=string.Empty;
        [Required]
        public string ProducImage { get; set; }=string.Empty;

        public string Status {  get; set; }=OrderStatus.CreateStatus;
        public List<OrderItem> Items { get; set;} = new List<OrderItem>();


    }
}
