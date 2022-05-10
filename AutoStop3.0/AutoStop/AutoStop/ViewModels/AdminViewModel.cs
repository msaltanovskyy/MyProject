using Microsoft.AspNetCore.Identity;
using AutoStop.Models;
namespace AutoStop.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
        public IEnumerable <IdentityUser> Users { get; set; }
        public IEnumerable <CategoriesCar> CategoriesCars { get; set; }
        public IEnumerable<PointArrive> PointArrives { get; set;}
        public IEnumerable<PointSend> PointSends { get; set; } 
        public IEnumerable<BlackList> BlackList { get; set; }

        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<string> UserRoles { get; set; }
        public AdminViewModel()
        {
            Roles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
