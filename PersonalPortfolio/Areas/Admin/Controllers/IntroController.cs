using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IntroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<Intro> intros = _db.Intros.Where(i => i.IsActive == true && i.IsDeleted == false).ToList<Intro>();
            return Json(new { data = intros });
        }
        public IActionResult GetByID(Intro intro)
        {
            var result=_db.Intros.Where(i => i.IsActive == true && i.IsDeleted == false && i.Id==intro.Id);
            return Json(result);
        }
    }
}
