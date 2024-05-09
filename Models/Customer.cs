using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; }
        [Required, StringLength(15)]
        public string CustomerMobile { get; set; }
        [EmailAddress]
        public string? CustomerEmail { get; set; }
        [StringLength(100)]
        public string? CustomerAddress { get; set; }
        public List<SalesOrder>? SalesOrders { get; set; }
    }
}
