using AutoStop.Data;
using Microsoft.AspNetCore.Mvc;
using AutoStop.Models;
using System.Security.Claims;

namespace AutoStop.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CommentController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        
        
        [HttpGet("Comment/CreateComment/{TravelsId}")]
        public IActionResult CreateComment(int TravelsId)
        {
            ViewBag.AccountsId = User.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.TravelsId = TravelsId;
            return View();
        }
        [HttpPost("Comment/CreateComment/{TravelsId}")]
        public async Task<IActionResult> CreateComment(Comments comments, int? TravelsId)
        {
            await _context.Travels.FindAsync(TravelsId);
            if (TravelsId == null)
            {
                return NotFound();
            }
            _context.Comments.Add(comments); 
            await _context.SaveChangesAsync();
            return RedirectToAction("");
        }
    }
}
