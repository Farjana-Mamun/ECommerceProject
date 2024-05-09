using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        [Required]
        public int PurchaseOrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UnitId { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        [NotMapped]
        public decimal SubTotal { get; }

        [NotMapped]
        public string ProductName { get; set; }

        [NotMapped]
        public string UnitName { get; }
        public PurchaseOrder? PurchaseOrder { get; }
        public Product? Product { get; }
        public Unit? Unit { get; }
    }
}
