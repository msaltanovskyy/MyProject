using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class CarCategories
    {
        [Key]
        public int Id { get; set; } 
        public int CarId { get; set; }
        public Cars Car { get; set; }
        public int CategoriesId { get; set; }
        public CategoriesCar Category { get; set; }
    }
}
