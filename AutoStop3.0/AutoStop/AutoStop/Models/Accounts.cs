using Microsoft.AspNetCore.Identity;

namespace AutoStop.Models
{
    public class Accounts : IdentityUser
    {
 
        public string Nikcname { get; set; }
        public override string UserName { get; set; }
        public string LastName { get; set; }

        public ICollection<Cars> Cars { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Travels> Travels { get; set; } 
        public ICollection<BusyPlaces> BusyPlaces { get; set; }

        public int BlackListId { get; set; }    
        public BlackList BlackList { get; set; }
    }
}
