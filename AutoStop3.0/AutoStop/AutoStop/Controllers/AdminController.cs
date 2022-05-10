using AutoStop.Data;
using AutoStop.Models;
using AutoStop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoStop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(RoleManager<IdentityRole> _roleManager, UserManager<IdentityUser> _userManager, ApplicationDbContext ctx)
        {
            this._roleManager = _roleManager;
            this._userManager = _userManager;
            this._context = ctx;
        }
        // GET: AdminController
        /// <summary>
        /// Index(List role, user, categories, points, black list)
        /// </summary>
        /// <returns>return View models</returns>
        public ActionResult Index()
        {
            List<IdentityRole> roles = _context.Roles.Select(r => new IdentityRole
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
            List<IdentityUser> user = _context.Users.Select(u => new IdentityUser
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
            }).ToList();

            List<CategoriesCar> categories = _context.Categories.Select(c => new CategoriesCar
            {
                Name = c.Name,
                Id = c.Id,
                Discription = c.Discription,
            }).ToList();

            List<PointSend> pointSends = _context.PointSends.Select(p => new PointSend
            {
                Id = p.Id,
                PointName = p.PointName,
            }).ToList();

            List<PointArrive> pointArrives = _context.PointArrives.Select(p => new PointArrive
            {
                Id = p.Id,
                PointName = p.PointName,
            }).ToList();

            List<BlackList> blackLists = _context.BlackList.Select(b => new BlackList
            {
                Id = b.Id,
                Accounts = b.Accounts,
                Reason = b.Reason

            }).ToList();

            AdminViewModel adm = new AdminViewModel()
            {
                Roles = roles,
                Users = user,
                CategoriesCars = categories,
                PointArrives = pointArrives,
                PointSends = pointSends,
                BlackList = blackLists
            };
            return View(adm);
        }


        ///////////////////////ROLE////////////////////////////
        [HttpGet]
        public ActionResult AddRole()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRole(IdentityRole role)
        {

            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index");
        }

        [HttpGet("/Admin/DeleteRole/{id}")]
        public ActionResult RoleDelete()
        {
            return View();
        }

        [HttpPost("/Admin/DeleteRole/{id}")]
        public async Task<ActionResult> RoleDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return Json(_context.Roles.ToList());
        }

        ///////////////////////CATEGORY////////////////////////////
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoriesCar categories)
        {
            _context.Categories.Add(categories);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/CategryDelete/{id}")]
        public ActionResult CategoryDelete()
        {
            return View();
        }
        [HttpPost("Admin/CategryDelete/{id}")]
        public async Task<ActionResult> CategoryDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Json(_context.Categories.ToList());

        }
        [HttpGet("Admin/CategoryEdit/{id}")]
        public async Task<ActionResult> CategoryEdit(int id)
        {

            if (id == 0)
                return View(new CategoriesCar());
            else
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }

        [HttpPost("/Admin/CategoryEdit/{id}")]
        public async Task<ActionResult> CategoryEdit(int? id, CategoriesCar car)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        ////////////////////////POINTSEND//////////////////////////
        [HttpGet]
        public ActionResult AddPointSend()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddPointSend(PointSend send)
        {
            _context.PointSends.Add(send);
            await _context.SaveChangesAsync();
            return View();
        }

        [HttpGet("Admin/DeletePointSend/{id}")]
        public ActionResult DeletePointSend()
        {
            return View();
        }
        [HttpPost("Admin/DeletePointSend/{id}")]
        public async Task<ActionResult> DeletePointSend(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointSend = await _context.PointSends.FindAsync(id);
            _context.PointSends.Remove(pointSend);
            _context.SaveChanges();
            return Json(_context.PointSends.ToList());
        }

        ///////////////////////POINTARRIVE////////////////////////////
        [HttpGet]
        public ActionResult AddPointArrive()
        {
            return View();
        }

        public async Task<ActionResult> AddPointArrive(PointArrive arrive)
        {
            _context.PointArrives.Add(arrive);
            await _context.SaveChangesAsync();
            return View();
        }

        [HttpGet("Admin/DeletePointArrive/{id}")]
        public ActionResult DeletePointArrive()
        {
            return View();
        }
        [HttpPost("Admin/DeletePointArrive/{id}")]
        public async Task<ActionResult> DeletePointArrive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pointArrive = await _context.PointArrives.FindAsync(id);
            _context.PointArrives.Remove(pointArrive);
            _context.SaveChanges();
            return Json(_context.PointArrives.ToList());
        }

        ////////////////////////ADDROLEUSER/////////////////////////////////
        [HttpGet]
        public async Task<ActionResult> SelectRole(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                AdminViewModel model = new AdminViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    Roles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> SelectRole(string userId,List<string> roles)
        {

            // получаем пользователя
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet("Admin/AddBlackList/")]
        public IActionResult AddBlackList()
        {
            List<IdentityUser> user = _context.Users.Select(u => new IdentityUser
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
            }).ToList();
            ViewBag.AccountId = new SelectList(user, "id");
            return View();
        }

        [HttpPost("Admin/AddBlackList/")]
        public IActionResult AddBlackList(BlackList blackList)
        { 
            _context.Add(blackList);
            _context.SaveChanges();

            return View();
        }
    }
}
