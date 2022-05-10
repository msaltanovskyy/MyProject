using System.ComponentModel.DataAnnotations;

namespace AutoStop.Models
{
    public class BusyPlaces
    {
        [Key]
        public int Number { get; set; } 
        public int TravelId { get; set; }
        [Display(Name = "Номер поездки")]
        public Travels Traverl { get; set; }
        public int BusyPlace { get; set; }
        public string AccountId { get; set; }
        [Display(Name = "Индификатор акк")]
        public Accounts Accounts { get; set; }  
    }
}
