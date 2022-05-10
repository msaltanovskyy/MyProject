using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class CategoriesCar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name category")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter discription")]
        [MaxLength(200, ErrorMessage = "Maxlength 200 symbols")]
        public string Discription { get; set; }

        public ICollection<CarCategories> CarCategories { get; set; }
    }
}
