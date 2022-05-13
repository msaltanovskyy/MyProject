using Microsoft.AspNetCore.Mvc;
using Observatory.Data;
using Observatory.Models;

namespace Observatory.Controllers
{
    public class ObservatoryController : Controller
    {
        private readonly ObservatoryDbContext _context;
        public ObservatoryController(ObservatoryDbContext ctx)
        {
            _context = ctx;
        }
        public ActionResult Index()
        {
            var area = _context.area.ToList();
            return View(area);
        }

        [HttpGet]
        public ActionResult AreaCreate()
        {
            return View(); 
        }

        [HttpPost("Observatory/AreaCreate")]
        public ActionResult AreaCreate(Area area)
        {
            _context.Add(area);
            _context.SaveChanges();
            return View();
        }

        [HttpGet("Observatory/Index/{id}")]
        public ActionResult ViewArea(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var area = _context.area.Find(id);
       
            return View(area);
        }
    }
}
