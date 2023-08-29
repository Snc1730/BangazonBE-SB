using System.ComponentModel.DataAnnotations;

namespace BangazonBE_SB.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool IsSeller { get; set; }
    }
}
