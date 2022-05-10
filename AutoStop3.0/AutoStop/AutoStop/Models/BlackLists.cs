using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class BlackList
    {
        [Key]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public Accounts Accounts { get; set; }
        public string Reason { get; set; } 
    }
}
