using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class PointArrive
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "PointArrive enter")]
        [MaxLength(50, ErrorMessage = "Maxlength 50 symbols")]
        public string PointName { get; set; }

        public List<Travels> Travels { get; set; }
    }
}
