using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Observatory.Models
{
    public class Planets
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Размер по X")]
        public double SizeX { get; set; }
        [Display(Name = "Размер по Y")]
        public double SizeY { get; set; }
        [Display(Name = "Размер по Z")]
        public double SizeZ { get; set; }
        [Display(Name = "Масса")]
        public double Mass { get; set; }
        [Display(Name = "Температура")]
        public double Temperature { get; set; }
        public string InfoLink { get; set; }
        public string Model3d { get; set; }
        
    }
}
