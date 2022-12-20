using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutMeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AboutMeController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            List<AboutMe> aboutMes=_db.AboutMe.Where(a=>a.IsActive==true && a.IsDeleted == false).ToList<AboutMe>();
            return Json(new { data = aboutMes });
        }   
    }
}
