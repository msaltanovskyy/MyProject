using System.ComponentModel.DataAnnotations;

namespace Observatory.Models
{
    public class Area
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

        public IEnumerable<Planets> Planets { get; set; }
    }
}
