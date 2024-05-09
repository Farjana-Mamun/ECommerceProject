using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string? ImageName { get; set; }

        [Required, StringLength(150)]
        public string ImageCode { get; set; }
        public decimal? ImageSize { get; set; }
        public string ImageExt { get; set; }
        public Product? Product { get; set; }
    }
}
