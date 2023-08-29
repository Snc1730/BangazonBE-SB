using System.ComponentModel.DataAnnotations;

namespace BangazonBE_SB.Models
{
    public class ProductCategories
    {
        [Key]
        public int ProductCatagoryId { get; set; }
        public string? Name { get; set; }
    }
}
