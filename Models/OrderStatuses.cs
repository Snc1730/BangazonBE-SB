using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonBE_SB.Models
{
    public class OrderStatuses
    {
        [Key]
        public int OrderStatusId { get; set; }
        public string? OrderStatus { get; set; }
    }
}

