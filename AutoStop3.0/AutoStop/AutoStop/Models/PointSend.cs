using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class PointSend
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "PointSend enter")]
        [MaxLength(50, ErrorMessage = "Maxlength 50 symbols")]
        public string PointName { get; set; }

        public ICollection<Travels> Travels { get; set; }

    }
}
