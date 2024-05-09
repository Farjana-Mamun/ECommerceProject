using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int UnitId { get; }

        [Required]
        public int ProductModelId { get; set; }

        [Required]
        public int ConfigurationId { get; set; }

        [Required, StringLength(15)]
        public string ProductCode { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        public decimal Weight { get; set; }

        public decimal WarnPoint { get; set; }

        public int ProductWarranty { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        public decimal VAT { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

        [StringLength(100)]
        public string ShortDescription { get; set; }

        [StringLength(300)]
        public string LongDescription { get; set; }

        [Required, StringLength(50)]
        public string ProductName { get; set; }

        public bool DiscountInPercent { get; set; }

        public decimal DiscountAmount { get; set; }

        public SubCategory? SubCategories { get; set; }

        public Brand? Brand { get; set; }

        public Unit? Unit { get; set; }

        public ProductModel? ProductModel { get; set; }

        public Configuration? Configuration { get; set; }

        public List<ProductImage>? ProductImages { get; set; }
        public List<SaleDetail>? SaleDetails { get; set; }
        public List<Stock>? Stocks { get; set; }
        public List<PurchaseDetail>? PurchaseDetails { get; set; }
    }
}
