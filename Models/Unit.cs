using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Unit
    {
        public int Id { get; set; }

        [Required, StringLength(15)]
        public string UnitName { get; set; }
        public List<Product>? Products { get; set; }
        public List<PurchaseDetail>? PurchaseDetails { get; set; }
        List<SaleDetail>? SaleDetails { get; set; }
    }
}
