using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AutoStop.Models
{
    public class Cars
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Номер машины")]
        public string NumberCar { get; set; }

        [DisplayName("Модель автомобиля")]
        [Required(ErrorMessage = "Enter model car")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Model { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Enter discription")]
        [MaxLength(200, ErrorMessage = "Maxlength 200 symbols")]
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }

        [DisplayName("Количестов мест")]
        public int Chair { get; set; }

        [DisplayName("Водитель")]
        public string DriverId { get; set; }
        [DisplayName("Водитель")]
        public Accounts Drivers { get; set; }

        [DisplayName("Категория")]
        public ICollection<CarCategories> CarCategories { get; set; }

    }
}
