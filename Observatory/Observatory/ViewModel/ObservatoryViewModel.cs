using Observatory.Models;

namespace Observatory.ViewModel
{
    public class ObservatoryViewModel
    {
        public IEnumerable<Planets> planets { get; set; }
        public IEnumerable<Area> areas { get; set; }
    }
}
