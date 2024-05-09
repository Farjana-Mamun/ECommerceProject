using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string ConfigurationName { get; set; }
        public List<Product>? Products { get; set; }
    }
}
