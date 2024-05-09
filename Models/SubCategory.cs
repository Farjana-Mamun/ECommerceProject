using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string SubCatategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Product>? Products { get; set; }
    }
}
