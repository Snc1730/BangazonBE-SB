using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonBE_SB.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public int ProductCategoryId { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
