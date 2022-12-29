using Microsoft.AspNetCore.Mvc;
using PersonalPortfolio.Data;
using PersonalPortfolio.Models;

namespace PersonalPortfolio.Controllers
{
    public class IntroPhotoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IntroPhotoController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
            IntroPhoto introphotos = _db.introPhotos.FirstOrDefault(i => i.IsActive == true && i.IsDeleted == false);
            return Json(introphotos );
        }
    }
}
