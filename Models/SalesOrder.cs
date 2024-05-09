using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required, StringLength(15)]
        public string InvoiceNumber { get; set; }
        public decimal TotalBillAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal VAT { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal NetPayableBill { get; set; }

        [StringLength(300)]
        public string Remarks { get; set; }
        public Customer? Customer { get; set; }
        public List<SaleDetail>? SaleDetails { get; set; }
    }
}
