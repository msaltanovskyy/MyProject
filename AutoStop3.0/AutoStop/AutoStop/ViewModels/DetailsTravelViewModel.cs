using AutoStop.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoStop.ViewModels
{
    public class DetailsTravelViewModel
    {
        public Travels travels { get; set; }
        public IEnumerable<Comments> comments { get; set; }
    }
}
