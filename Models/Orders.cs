using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonBE_SB.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public ICollection <Products> Products { get; set; }
        public int StatusId { get; set; }
    }
}
