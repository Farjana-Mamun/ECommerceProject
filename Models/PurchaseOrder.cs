using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ECommerceProject.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Required, StringLength(50)]
        public DateTime InvoiceNo { get; set; }

        [Required]
        public decimal TotalPurchasePrice { get; set; }
        public decimal VAT { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetPayableAmount { get; set; }
        public Vendor? Vendor { get; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
