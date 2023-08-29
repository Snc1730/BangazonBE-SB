using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonBE_SB.Models
{
    public class Users_PaymentTypes
    {
        [Key]
        public int UserPaymentTypeId { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public ICollection <User> Users { get; set; }
        public ICollection <PaymentTypes> PaymentTypes { get; set; }
    }
}
