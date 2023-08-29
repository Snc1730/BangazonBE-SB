using System.ComponentModel.DataAnnotations;

namespace BangazonBE_SB.Models
{
    public class PaymentTypes
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string? Name { get; set; }
    }
}
