using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class SaleDetail
    {
        public int Id { get; set; }

        [Required]
        public int SalesOrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SaleQuantity { get; set; }

        [NotMapped]
        public int SubTotal { get; set; }

        [NotMapped]
        public string ProductName { get; set; }

        [NotMapped]
        public string UnitName { get; set; }

        public SalesOrder? SalesOrder { get; set; }
        public Product? Product { get; set; }
        public Unit? Unit { get; set; }
    }
}
