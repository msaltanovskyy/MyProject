using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(500,ErrorMessage = "Maxlength 500 symbols")]
        public string ?Comment { get; set; }

        public string AccountsId { get; set; }
        public Accounts Accounts { get; set; }

        public int TravelsId { get; set; }
        public Travels Travels { get; set; }  
        
    }
}
