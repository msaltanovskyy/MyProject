using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoStop.Models
{
    public class Travels
    {
        [Key]
        public int Number { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime TimeCreate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Время отправления")]
        [Required(ErrorMessage = "Enter time send")]
        [DataType(DataType.DateTime)]
        public DateTime TimeSend
        {
            get{ return _Send.ToUniversalTime(); }

            set{ _Send = value; }
        }
        [Display(Name = "Время прибытия")]
        [Required(ErrorMessage = "Enter time arrive")]
        [DataType(DataType.DateTime)]
        public DateTime TimeArrive
        {
            get { return _Arrive.ToUniversalTime(); } 
                
            set { _Arrive=value; }

        }
        [Display(Name = "Доступные места")]
        public int AvailableSeats { get; set; }
        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }
        [Display(Name = "Статус")]
        public bool Status { get; set; } = false;


        public int CarId {get;set;}
        [Display(Name = "Автомобиль")]
        public Cars Car { get; set; }

        public int PointSendId { get; set; }
        [Display(Name = "Точка прибытия")]
        public PointSend PointSend { get; set; }
        public int PointArriveId { get; set; }
        [Display(Name = "Точка отправления")]
        public PointArrive PointArrive { get; set; }

        public string CreaterId { get; set; }
        [Display(Name = "Создатель")]
        public Accounts Creater { get; set; }
        
        public ICollection<BusyPlaces> BusyPlaces { get; set; }
        public ICollection<Comments> Comments { get; set; }



        [NotMapped]
        [DataType(DataType.DateTime)]
        public DateTime _Arrive { get; set; }
        [NotMapped]
        [DataType(DataType.DateTime)]
        public DateTime _Send { get; set; }
 
    }
}
